using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Data.SqlClient;
using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Enums;
using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities;
using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Events;
using Filuet.Utils.Common.Business;
using Filuet.Utils.Extensions;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Core
{
    public class UvsAdapter : IUvsAdapter
    {
        private UvsDepMode _uvsDepMode { get ; set ; }

        public event EventHandler<UvsIncomeEventArgs> OnUvsPayment;
        public event EventHandler<UvsOrderCancelEventArgs> OnUvsOrderCancelled;

        public UvsAdapter(UvsDepMode dep = UvsDepMode.Operator) => _uvsDepMode = dep;

        /// <summary>
        /// Add Order information to UVS database
        /// </summary>
        /// <param name="orderNumber">Order number from Oracle</param>
        /// <param name="dsId">Partner key, get from Oracle</param>
        /// <param name="dsName">Partner name, get from Oracle</param>
        /// <param name="totaldue">Total order amount</param>
        /// <param name="orderLines">Order product positions information</param>
        public bool CreateOrder(string orderNumber, string dsId, string dsName, decimal totaldue, IEnumerable<OrderLine> orderLines)
        {
            using (var db = new UvsDataEntities())
            {
                var pluSet = AddPluSet(db.Plusets, db.PlusetLines, orderNumber, dsId);

                var resultLines = Shake(orderLines, totaldue);

                Func<string, int> getSkuId = (sku) => orderLines.Single(x => x.Sku == sku).SkuId;
                Func<string, string> getSkuName = (sku) => orderLines.Single(x => x.Sku == sku).SkuName;
                Func<string, bool> getNds = (sku) => orderLines.Single(x => x.Sku == sku).Nds21Percent;

                IEnumerable<string> skus = orderLines.Select(x => x.Sku);

                bool result = false;

                foreach (var s in skus)
                {
                    foreach (var line in resultLines.Where(x => string.Equals(x.Sku, s, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        try
                        {
                            BarKodai bk = AddBarKodai(db.BarKodai, getSkuId(line.Sku), line.Sku);
                            if (bk.Id <= 0)
                                db.SaveChanges();
                        }
                        catch { }
                        try
                        {
                            Preke pr = AddPreke(db.Prekes, line.SkuId, line.Sku, getSkuName(line.Sku), getNds(line.Sku));
                            if (pr.Id <= 0)
                                db.SaveChanges();
                        }
                        catch { }
                        try
                        {
                            AddPluSetLine(db.PlusetLines, orderNumber, line.Sku, line.Qty, (double)Math.Round(line.Price / line.Qty, 2));
                            int id = db.SaveChanges();
                            result = id > 0;
                        }
                        catch (Exception ex)
                        { }
                    }
                }

                if (result)
                    AddAttributeToReceipt(db.Database, pluSet.Id, dsId, dsName);

                return result;
            }
        }

        /// <summary>
        /// Get information about order payment from UVS
        /// </summary>
        /// <param name="orderNumber">Order number from Oracle</param>
        /// <returns></returns>
        public bool ConfirmPayment(string orderNumber)
        {
            using (UvsDataEntities db = new UvsDataEntities())
            {
                int paymentId = 0;
                (bool success, PaymentMethod method, decimal amount, string message) res
                    = CheckPaymentStatus(db.SellDiscount, db.Payment, orderNumber, ref paymentId);

                if (res.success)
                    OnUvsPayment?.Invoke(this, UvsIncomeEventArgs.Create(paymentId, res.method.GetCode(), res.amount));
                
                return res.success;
            }
        }

        public bool CancelOrder(string orderNumber)
        {
            orderNumber = orderNumber.Trim();

            using (UvsDataEntities db = new UvsDataEntities())
            {
                orderNumber = orderNumber.Trim();
                Pluset set = db.Plusets.FirstOrDefault(plu => plu.Barcode == orderNumber);

                if (set != null && set.Kgid == 0)
                {
                    set.Kgid = -1;
                    db.SaveChanges();

                    OnUvsOrderCancelled?.Invoke(this, UvsOrderCancelEventArgs.Create(true, $"{orderNumber} has been canceled"));
                    return true;
                }
                else
                {
                    OnUvsOrderCancelled?.Invoke(this, UvsOrderCancelEventArgs.Create(false, $"Unable to cancel order '{orderNumber}'!{(set == null ? " Order not found!" : string.Empty)}{(set != null && set.Kgid > 0 ? $" Order payed. KGID={set.Kgid}" : "")}"));
                    return false; 
                }
            }
        }

        public bool IsOrderCanceled(string orderNumber)
        {
            using (var db = new UvsDataEntities())
            {
                orderNumber = orderNumber.Trim();
                Pluset set = db.Plusets.FirstOrDefault(plu => plu.Barcode == orderNumber.Trim());

                return set == null || set.Kgid == -1;
            }
        }

        /// <summary>
        /// Specify working mode: operator or POS terminal
        /// </summary>
        /// <param name="mode"></param>
        public void SetDepMode(UvsDepMode mode)
        {
            _uvsDepMode = mode;
        }

        #region Private
        private static int ConvertOrderNumberToNumberValue(string orderNumber)
        {
            if (!int.TryParse(orderNumber, out var setNo))
                throw new ArgumentException(@"Order number should contain numbers!", nameof(orderNumber));
            return setNo;
        }

        private Pluset AddPluSet(DbSet<Pluset> pluSets, DbSet<PlusetLine> pluSetLines, string orderNumber, string dsId)
        {
            var pluSet = pluSets.SingleOrDefault(plu => string.Equals(plu.Barcode, orderNumber));
            if (pluSet != null && pluSet.Kgid <= 0)
            {
                foreach (var lineToRemove in pluSetLines.Where(l => l.Setno == pluSet.SetNo))
                    pluSetLines.Remove(lineToRemove);
                pluSets.Remove(pluSet);
            }

            var setNo = ConvertOrderNumberToNumberValue(orderNumber);
            var createdate = DateTime.Now;
            var barcode = orderNumber; //сюда записываем полный/с буквами НомерЗаказа из Oracle
            const int pricemode = 2; //2 - значит цена формируется по PLUSetLines
            const string paytype = " "; //непонятно что писать, поставлю пока 0 <--???
            const int reservation = 100; //резерв на 100 дней
            const int pickuplace = 0;
            const int kgid = 0;

            var pluSetOut = new Pluset
            {
                Createdate = createdate,
                SetNo = setNo,
                Barcode = barcode,
                Dep = (int)_uvsDepMode,
                Pricemode = pricemode,
                Paytype = paytype,
                Reservation = reservation,
                Pickuplace = pickuplace,
                Kgid = kgid,
                Customer = ""//dsId
            };

            return pluSets.Add(pluSetOut).Entity;
        }

        private BarKodai AddBarKodai(DbSet<BarKodai> barKodais, int skuId, string sku)
        {
            int dep = (int)_uvsDepMode;
            var barKodai = barKodais.SingleOrDefault(x => x.PrekesKodas == skuId && x.BarCode == sku && x.Dep == dep);
            if (barKodai != null)
                return barKodai;

            var barKodaiOut = new BarKodai()
            {
                PrekesKodas = skuId,
                BarCode = sku,
                Dep = (int)_uvsDepMode
            };

            return barKodais.Add(barKodaiOut).Entity;
        }

        private Preke AddPreke(DbSet<Preke> prekes, int skuId, string sku, string skuName, bool nds21)
        {
            int dep = (int)_uvsDepMode;
            var preke = prekes.FirstOrDefault(x => x.PrekesKomentaras == sku && x.Dep == dep);// Obsolete: prk.PrekesKodas == skuId); // FirstOrDefault because there are several sku-s in rdata
            if (preke != null)
            {
                return preke;
            }

            var kodas = skuId;
            var pavadinimas = skuName;
            var komentaras = sku;
            var grupesId = nds21 ? 2 : 1;

            const int kaina = 0;
            const byte matas = 1; //единица измерения из таблицы MatavimoVienetai
            const int kiekis = 0;
            const bool aktyvi = true;
            const short priceType = 1;
            const int blockType = 0;

            Func<byte[], Preke> AddPreke = (aparatai) =>
            {
                return prekes.Add(new Preke
                {
                    PrekesPavadinimas = pavadinimas,
                    PrekesKomentaras = komentaras,
                    PrekesKaina = kaina,
                    PrekesMatas = matas,
                    PrekesKiekis = kiekis,
                    PrekesKodas = kodas,
                    GrupesId = grupesId,
                    Aktyvi = aktyvi,
                    Aparatai = aparatai,
                    Dep = (int)_uvsDepMode,
                    PriceType = priceType,
                    BlockType = blockType,
                    Updating = false,
                    NType = 0
                }).Entity;
            };

            switch (dep)
            {
                case 1:
                    byte[] ap1 = { 1 };
                    return AddPreke(ap1);
                case 2:
                    byte[] ap2 = { 2 };
                    return AddPreke(ap2);
                case 3:
                    byte[] ap3 = { 4 };
                    return AddPreke(ap3);
                case 4:
                    byte[] ap4 = { 8 };
                    return AddPreke(ap4);
            }

            return null;
        }

        private PlusetLine AddPluSetLine(DbSet<PlusetLine> pluSetLines, string orderNumber, string sku, int qty, double price)
        {
            var setno = ConvertOrderNumberToNumberValue(orderNumber);
            const int tax = 0;
            const int packcount = 0;
            const byte priceMode = 128;

            var pluSetLine = new PlusetLine()
            {
                Dep = (int)_uvsDepMode,
                Setno = setno,
                Barcode = sku,
                Qty = qty,
                Price = price,
                Tax = tax,
                Packcount = packcount,
                PriceMode = priceMode
            };

            pluSetLines.Add(pluSetLine);

            return pluSetLine;
        }

        /// <summary>
        /// In table PLUSetAttributes we does`t have primary key so we can`t use entity for add/update/delete functionality.
        /// </summary>
        /// <param name="attributes"></param>
        /// <param name="pluSetId"></param>
        /// <param name="attributeId"></param>
        /// <param name="attributeValue"></param>
        private void AddAttribute(DatabaseFacade attributes, int pluSetId, string attributeId, string attributeValue)
        {
            attributes.ExecuteSqlCommand("INSERT INTO [PLUSetAttributes] ([PLUSetId],[AttributeId],[Value]) VALUES (@pluSetId, @attributeId, @attributeValue)",
                new SqlParameter("pluSetId", pluSetId),
                new SqlParameter("attributeId", attributeId),
                new SqlParameter("attributeValue", attributeValue));
        }

        private void AddAttributeToReceipt(DatabaseFacade attributes, int pluSetId, string dsId, string dsName)
        {
            AddAttribute(attributes, pluSetId, "setid", dsId);
            AddAttribute(attributes, pluSetId, "setname", dsName);
        }

        private SellDiscount GetPluSell(IQueryable<SellDiscount> sellDiscount, string orderNumber)
            => sellDiscount.FirstOrDefault(sd => sd.CardNo == orderNumber);

        /// <summary>
        /// <remarks>
        /// If Type  == 0 it`s Cash payment
        /// Else if Type  == 6 it`s Card payment
        /// </remarks>
        /// </summary>
        /// <param name="payments"></param>
        /// <param name="galvosId"></param>
        /// <returns></returns>
        private IQueryable<Payment> GetPaymentInformation(IQueryable<Payment> payments, int galvosId)
        {
            return payments.Where(p => p.GalvosId == galvosId);
        }

        private (bool success, PaymentMethod method, decimal amount, string message) CheckPaymentStatus(IQueryable<SellDiscount> sellDiscounts, IQueryable<Payment> payments, string orderNumber, ref int paymentId)
        {
            SellDiscount sell = GetPluSell(sellDiscounts, orderNumber.Trim());
            if (sell == null)
                return (false, PaymentMethod.Card, 0m, "Unable to find order");

            IEnumerable<Payment> paymentInfoes = GetPaymentInformation(payments, sell.GalvosId).ToList();

            foreach (var payment in paymentInfoes)
            {
                if (payment.Type == 0)
                {
                    paymentId = payment.Id;
                    return (true, PaymentMethod.Cash, (decimal)payment.Amount, string.Empty);
                }
                if (payment.Type == 6 || payment.Type == 4 /*UVS test*/)
                {
                    paymentId = payment.Id;
                    return (true, PaymentMethod.Card, (decimal)payment.Amount, string.Empty);
                }
            }

            return (false, PaymentMethod.Card, 0m, "Unable to find the payment");// new GenericResult(GenericResultCodes.FAILURE, Int32.MinValue, @"The unknown result of payment!");
        }

        private IEnumerable<OrderLine> Shake(IEnumerable<OrderLine> items, decimal totalAmount)
        {
            if (Math.Abs(totalAmount - items.Sum(x => x.Price)) > 0.1m)
                throw new Exception($"Invalid pricing data. Total amount: {totalAmount}. Items amount: {(decimal)items.Sum(x => x.Price)}");

            ICollection<OrderLine> result = new List<OrderLine>();

            items = items.OrderByDescending(x => x.Qty);

            bool isSingle = items.Count() == 1;

            decimal delta = Math.Round(totalAmount - items.Sum(x => Math.Round(x.Price, 2)), 2); // because double itemPrice = Math.Round(i.Price, 2);

            foreach (var i in items)
            {
                bool isLast = items.Last().Sku == i.Sku;

                decimal itemPrice = Math.Round(i.Price, 2);

                decimal newPrice = itemPrice + delta;
                if (i.Qty == 1) // if single
                {
                    result.Add(new OrderLine { Sku = i.Sku, Qty = i.Qty, Price = newPrice, Nds21Percent = i.Nds21Percent, SkuId = i.SkuId, SkuName = i.SkuName });
                    delta = 0;
                    continue;
                }

                decimal unitCost = 0;

                #region (total unitCost * quantity) must be less than total line
                decimal unitCost1 = Math.Round(newPrice / i.Qty, 2, MidpointRounding.AwayFromZero);
                decimal unitCost2 = Math.Round(newPrice / i.Qty, 2, MidpointRounding.ToEven);
                delta = 0;

                bool notUnitCost1 = Math.Round(unitCost1 * i.Qty - newPrice, 2) > 0;
                bool notUnitCost2 = Math.Round(unitCost2 * i.Qty - newPrice, 2) > 0;

                if (!notUnitCost1 && notUnitCost2)
                    unitCost = unitCost1;

                if (notUnitCost1 && !notUnitCost2)
                    unitCost = unitCost2;

                if (!notUnitCost1 && !notUnitCost2)
                {
                    if (Math.Abs(unitCost1 * i.Qty - newPrice) <= Math.Abs(unitCost2 * i.Qty - newPrice))
                        unitCost = unitCost1;
                    else unitCost = unitCost2;
                }

                if (notUnitCost1 && notUnitCost2)
                {
                    unitCost1 = Math.Round(unitCost1 - 0.01m, 2);
                    unitCost2 = Math.Round(unitCost2 - 0.01m, 2);

                    if (Math.Abs(unitCost1 * i.Qty - newPrice) <= Math.Abs(unitCost2 * i.Qty - newPrice))
                        unitCost = unitCost1;
                    else unitCost = unitCost2;
                }
                #endregion

                delta = Math.Round(newPrice - unitCost * i.Qty, 2);

                if (delta != 0 && isLast)
                {
                    if (Math.Abs(Math.Round(unitCost - Math.Round(newPrice - unitCost * (i.Qty - 1), 2), 2)) < 0.01m)
                        result.Add(new OrderLine { Sku = i.Sku, Qty = i.Qty, Price = Math.Round(unitCost * i.Qty, 2), Nds21Percent = i.Nds21Percent, SkuId = i.SkuId, SkuName = i.SkuName });
                    else
                    {
                        result.Add(new OrderLine { Sku = i.Sku, Qty = i.Qty - 1, Price = Math.Round(unitCost * (i.Qty - 1), 2), Nds21Percent = i.Nds21Percent, SkuId = i.SkuId, SkuName = i.SkuName });

                        if (i.Qty > 1) // can be omitted, because if (i.Qty == 1) ... continue ^
                            result.Add(new OrderLine { Sku = i.Sku, Qty = 1, Price = Math.Round(newPrice - unitCost * (i.Qty - 1), 2), Nds21Percent = i.Nds21Percent, SkuId = i.SkuId, SkuName = i.SkuName });
                    }
                    continue;
                }

                result.Add(new OrderLine { Sku = i.Sku, Qty = i.Qty, Price = Math.Round(i.Qty * unitCost, 2), Nds21Percent = i.Nds21Percent, SkuId = i.SkuId, SkuName = i.SkuName });
            }

            return result;
        }
        #endregion
    }
}

