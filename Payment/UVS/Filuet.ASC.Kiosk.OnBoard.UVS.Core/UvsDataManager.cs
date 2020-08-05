using System.Data.SqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using Filuet.ASC.Kiosk.OnBoard.UVS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Data.SqlClient;
using Filuet.ASC.Kiosk.OnBoard.UVS.Core.GenericResults;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Core
{
    public class UvsDataManager
    {
        public UvsDepMode UvsDepMode { get; set; }

        /// <summary>
        /// RData/SellDiscount/Id
        /// </summary>
        /// <param name="paymentId"></param>
        public delegate void UvsPaymentDataDelegate(string paymentId, string paymentMethod, decimal paymentAmount);
        public event UvsPaymentDataDelegate UvsPaymentData;

        public void Unsubscribe()
        {
            this.UvsPaymentData = null;
        }

        public UvsDataManager(UvsDepMode dep = UvsDepMode.Operator)
        {
            //Int32.TryParse(ConfigurationManager.AppSettings["UvsDepMode"], out dep);

            UvsDepMode = dep;
        }

        public bool TryConnect()
        {
            using (var db = new UvsDataEntities())
            {
                return true;
            }
        }

        //public long TotalRowsCount()
        //{
        //    if (TryConnect())
        //        using (var db = new UvsDataEntities())
        //        {
        //            // Note: move commant to utils
        //            DbRawSqlQuery<long> res = db.Database.SqlQuery<long>("SELECT SUM(i.rowcnt) FROM sysindexes AS i INNER JOIN sysobjects AS o ON i.id = o.id WHERE i.indid < 2  AND OBJECTPROPERTY(o.id, 'IsMSShipped') = 0");
                    
                    
        //            /*
        //             *             int customerId = 0;
        //    SqlParameter[] parameters = new SqlParameter[] {
        //        new SqlParameter("@uid", uid),
        //        new SqlParameter { ParameterName = "@customerId", Value = customerId, Direction = System.Data.ParameterDirection.Output }
        //    };

        //    DbContext.Database.ExecuteSqlCommand("SELECT @customerId = Id FROM  [dbo].[GetUsers]() WHERE DistributorId LIKE @uid", parameters);

        //    string customerIdAsString = parameters[1].Value.ToString();
        //    if (string.IsNullOrWhiteSpace(customerIdAsString))
        //        return 0;

        //    return Convert.ToInt32(customerIdAsString);
        //             * */


        //            return res.First();
        //        }

        //    return 0;
        //}

        public static int ConvertOrderNumberToNumberValue(string orderNumber)
        {
            if (!int.TryParse(orderNumber,out var setNo))
                throw new ArgumentException(@"Order number should contain numbers!", nameof(orderNumber));
            return setNo;
        }

        public bool IsPluSetExists(DbSet<PLUSet> pluSets, string orderNumber)
        {
            using (var db = new UvsDataEntities())
            {
                return db.PLUSets.Any(plu => string.Equals(plu.barcode, orderNumber));
            }
        }

        public PLUSet AddPluSet(DbSet<PLUSet> pluSets, DbSet<PLUSetLine> pluSetLines, string orderNumber, string dsId)
        {
            var pluSet = pluSets.SingleOrDefault(plu => string.Equals(plu.barcode, orderNumber));
            if (pluSet != null && pluSet.KGID <= 0)
            {
                foreach (var lineToRemove in pluSetLines.Where(l => l.setno == pluSet.setNo))
                    pluSetLines.Remove(lineToRemove);
                pluSets.Remove(pluSet);

                //    .barcode = $"{pluSet.barcode}_cancelled";
                //var cancelledOrderLines = pluSetLines.Where(l => l.setno == pluSet.setNo);


                //pluSet.setNo = -Math.Abs(pluSet.setNo);
            }

            var setNo = ConvertOrderNumberToNumberValue(orderNumber);
            var createdate = DateTime.Now;
            var barcode = orderNumber; //сюда записываем полный/с буквами НомерЗаказа из Oracle
            const int pricemode = 2; //2 - значит цена формируется по PLUSetLines
            const string paytype = " "; //непонятно что писать, поставлю пока 0 <--???
            const int reservation = 100; //резерв на 100 дней
            const int pickuplace = 0;
            const int kgid = 0;

            var pluSetOut = new PLUSet
            {
                createdate = createdate,
                setNo = setNo,
                barcode = barcode,
                dep = (int)UvsDepMode,
                pricemode = pricemode,
                paytype = paytype,
                reservation = reservation,
                pickuplace = pickuplace,
                KGID = kgid,
                customer = ""//dsId
            };

            pluSets.Add(pluSetOut);

            return pluSetOut;
        }

        public BarKodai AddBarKodai(DbSet<BarKodai> barKodais, int skuId, string sku)
        {
            int dep = (int)UvsDepMode;
            var barKodai = barKodais.SingleOrDefault(x => x.PrekesKodas == skuId && x.BarCode == sku && x.Dep == dep);
            if (barKodai != null)
                return barKodai;

            var barKodaiOut = new BarKodai()
            {
                PrekesKodas = skuId,
                BarCode = sku,
                Dep = (int)UvsDepMode
            };

            barKodais.Add(barKodaiOut);

            return barKodaiOut;
        }

        public Preke AddPreke(DbSet<Preke> prekes, int skuId, string sku, string skuName, bool nds21)
        {
            int dep = (int)UvsDepMode;
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
                    GrupesID = grupesId,
                    Aktyvi = aktyvi,
                    Aparatai = aparatai,
                    Dep = (int)UvsDepMode,
                    PriceType = priceType,
                    BlockType = blockType,
                    Updating = false,
                    N_Type = 0
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

        private PLUSetLine AddPluSetLine(DbSet<PLUSetLine> pluSetLines, string orderNumber, string sku, int qty, double price)
        {
            var setno = ConvertOrderNumberToNumberValue(orderNumber);
            const int tax = 0;
            const int packcount = 0;
            const byte priceMode = 128;

            var pluSetLine = new PLUSetLine()
            {
                dep = (int)UvsDepMode,
                setno = setno,
                BARCODE = sku,
                qty = qty,
                price = price,
                tax = tax,
                packcount = packcount,
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

        /// <summary>
        /// Add Order information to UVS database
        /// </summary>
        /// <param name="orderNumber">Order number from Oracle</param>
        /// <param name="dsId">Partner key, get from Oracle</param>
        /// <param name="dsName">Partner name, get from Oracle</param>
        /// <param name="totaldue">Total order amount</param>
        /// <param name="orderLines">Order product positions information</param>
        public bool AddOrderToPlu(string orderNumber, string dsId, string dsName, double totaldue, IList<OrderLine> orderLines)
        {
            using (var db = new UvsDataEntities())
            {
                var pluSet = AddPluSet(db.PLUSets, db.PLUSetLines, orderNumber, dsId);

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
                            BarKodai bk = AddBarKodai(db.BarKodais, getSkuId(line.Sku), line.Sku);
                            if (bk.ID <= 0)
                                db.SaveChanges();
                        }
                        catch { }
                        try
                        {
                            Preke pr = AddPreke(db.Prekes, line.SkuId, line.Sku, getSkuName(line.Sku), getNds(line.Sku));
                            if (pr.ID <= 0)
                                db.SaveChanges();
                        }
                        catch { }
                        try
                        {
                            AddPluSetLine(db.PLUSetLines, orderNumber, line.Sku, line.Qty, Math.Round(line.Price / line.Qty, 2));
                            int id = db.SaveChanges();
                            result = id > 0;
                        }
                        catch (Exception ex)
                        { }
                    }
                }

                //foreach (var orderLine in orderLines)
                //{
                //    AddBarKodai(db.BarKodais, orderLine.SkuId, orderLine.Sku);
                //    AddPreke(db.Prekes, orderLine.SkuId, orderLine.Sku, orderLine.SkuName, orderLine.Nds21Percent);
                //    AddPluSetLine(db.PLUSetLines, orderNumber, orderLine.Sku, orderLine.Qty, orderLine.Price);
                //}

                //  int id = db.SaveChanges();

                if (result)
                    AddAttributeToReceipt(db.Database, pluSet.ID, dsId, dsName);

                return result;
            }
        }

        public SellDiscount GetPluSell(IQueryable<SellDiscount> sellDiscounts, string orderNumber)
            => sellDiscounts.FirstOrDefault(sd => sd.CardNo == orderNumber);

        /// <summary>
        /// <remarks>
        /// If Type  == 0 it`s Cash payment
        /// Else if Type  == 6 it`s Card payment
        /// </remarks>
        /// </summary>
        /// <param name="payments"></param>
        /// <param name="galvosId"></param>
        /// <returns></returns>
        public IQueryable<Payment> GetPaymentInformation(IQueryable<Payment> payments, int galvosId)
        {
            return payments.Where(p => p.GalvosId == galvosId);
        }

        /// <summary>
        /// Get information about order payment from UVS
        /// </summary>
        /// <param name="orderNumber">Order number from Oracle</param>
        /// <param name="cancelMonitor">token to cancel monitoring operation</param>
        /// <returns></returns>
        public IGenericResult GetOrderPaymentResult(string orderNumber)
        {
            using (var db = new UvsDataEntities())
            {
                int paymentId = 0;
                var res = CheckPaymentStatus(db.SellDiscounts, db.Payments, orderNumber, ref paymentId);
                if (res.GenericResultCode != GenericResultCodes.Unknown)
                {
                    string paymentMethod = string.Empty;

                    switch (res.Code)
                    {
                        case 0:
                            paymentMethod = "cash";
                            break;
                        case 6:
                            paymentMethod = "card";
                            break;
                        case 9:
                            paymentMethod = "certificate";
                            break;
                        default:
                            throw new Exception($"Unknown payment method '{paymentMethod}'");
                    }

                    decimal paymentAmount = 0m;
                    if (res.SubResults.Any())
                        decimal.TryParse(res.SubResults[0].Description, out paymentAmount);

                    UvsPaymentData(paymentId.ToString(), paymentMethod, paymentAmount);
                    return res;
                }

                return new GenericResult(GenericResultCodes.FAILURE, 1, @"The payment is not finished!");
            }
        }

        public IGenericResult CheckPaymentStatus(IQueryable<SellDiscount> sellDiscounts, IQueryable<Payment> payments, string orderNumber, ref int paymentId)
        {
            var sell = GetPluSell(sellDiscounts, orderNumber.Trim());
            if (sell == null) return new GenericResult(GenericResultCodes.Unknown);

            var paymentInfo = GetPaymentInformation(payments, sell.GalvosId);

            foreach (var payment in paymentInfo)
            {
                if (payment.Type == 0)
                {
                    paymentId = payment.id;
                    GenericResult result = new GenericResult(GenericResultCodes.SUCCESS, 0, @"Payment conducted by cash");
                    result.SubResults.Add(new GenericResult(GenericResultCodes.SUCCESS, 0, payment.Amount.ToString()));
                    return result;
                }
                if (payment.Type == 6 || payment.Type == 4 /*UVS test*/)
                {
                    paymentId = payment.id;
                    GenericResult result = new GenericResult(GenericResultCodes.SUCCESS, 6, @"Payment conducted by card");
                    result.SubResults.Add(new GenericResult(GenericResultCodes.SUCCESS, 6, payment.Amount.ToString()));
                    return result;
                }
            }

            return new GenericResult(GenericResultCodes.FAILURE, Int32.MinValue, @"The unknown result of payment!");
        }

        public IGenericResult CancelOrder(string orderNumber)
        {
            using (var db = new UvsDataEntities())
            {
                orderNumber = orderNumber.Trim();
                PLUSet set = db.PLUSets.FirstOrDefault(plu => plu.barcode == orderNumber.Trim());

                if (set != null && set.KGID == 0)
                {
                    set.KGID = -1;
                    db.SaveChanges();

                    return new GenericResult(GenericResultCodes.SUCCESS, 0, $"Order '{orderNumber}' was canceled");
                }
                else return new GenericResult(GenericResultCodes.FAILURE, 0, $"Unable to cancel order '{orderNumber}'!{(set == null ? " Order not found!" : string.Empty)}{(set != null && set.KGID > 0 ? $" Order payed. KGID={set.KGID}" : "")}");
            }
        }

        public bool IsOrderCanceled(string orderNumber)
        {
            using (var db = new UvsDataEntities())
            {
                orderNumber = orderNumber.Trim();
                PLUSet set = db.PLUSets.FirstOrDefault(plu => plu.barcode == orderNumber.Trim());

                return set == null || set.KGID == -1;
            }
        }

        private IEnumerable<OrderLine> Shake(IEnumerable<OrderLine> items, double totalAmount)
        {
            if (Math.Abs(totalAmount - items.Sum(x => x.Price)) > 0.1)
                throw new Exception($"Invalid pricing data. Total amount: {totalAmount}. Items amount: {(decimal)items.Sum(x => x.Price)}");

            ICollection<OrderLine> result = new List<OrderLine>();

            items = items.OrderByDescending(x => x.Qty);

            bool isSingle = items.Count() == 1;

            double delta = Math.Round(totalAmount - items.Sum(x => Math.Round(x.Price, 2)), 2); // because double itemPrice = Math.Round(i.Price, 2);

            foreach (var i in items)
            {
                bool isLast = items.Last().Sku == i.Sku;

                double itemPrice = Math.Round(i.Price, 2);

                double newPrice = itemPrice + delta;
                if (i.Qty == 1) // if single
                {
                    result.Add(new OrderLine { Sku = i.Sku, Qty = i.Qty, Price = newPrice, Nds21Percent = i.Nds21Percent, SkuId = i.SkuId, SkuName = i.SkuName });
                    delta = 0;
                    continue;
                }

                double unitCost = 0;

                #region (total unitCost * quantity) must be less than total line
                double unitCost1 = Math.Round(newPrice / i.Qty, 2, MidpointRounding.AwayFromZero);
                double unitCost2 = Math.Round(newPrice / i.Qty, 2, MidpointRounding.ToEven);
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
                    unitCost1 = Math.Round(unitCost1 - 0.01, 2);
                    unitCost2 = Math.Round(unitCost2 - 0.01, 2);

                    if (Math.Abs(unitCost1 * i.Qty - newPrice) <= Math.Abs(unitCost2 * i.Qty - newPrice))
                        unitCost = unitCost1;
                    else unitCost = unitCost2;
                }
                #endregion

                delta = Math.Round(newPrice - unitCost * i.Qty, 2);

                if (delta != 0 && isLast)
                {
                    if (Math.Abs(Math.Round(unitCost - Math.Round(newPrice - unitCost * (i.Qty - 1), 2), 2)) < 0.01)
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
    }
}

