using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities;
using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.UVS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Tests
{
    public class UvsTest
    {
        [Theory]
        [InlineData("1234567891", 666.13, new double[] { 13, 653.13, 5 })]
        [InlineData("1234567891", 666.13, new double[] { 13, 653.13 })]
        public void Test_AddOrder(string orderNumber, decimal totalDue, double[] priceDue)
        {
            var uvsAdapter = new UvsAdapter();

            var orderLines = new List<OrderLine>();

            foreach (var price in priceDue)
            {
                orderLines.Add(new OrderLine()
                {
                    Nds21Percent = true,
                    Price = (decimal)price,
                    Qty = 1,
                    Sku = "test03",
                    SkuId = 666,
                    SkuName = "test04"
                });
            }

            if (totalDue - (decimal)priceDue.Sum() > 0.1m)
            {
                var result = uvsAdapter.CreateOrder(orderNumber, "test01", "test02", totalDue, orderLines);

                Assert.True(result);
            }
            else
            {
                try
                {
                    var result = uvsAdapter.CreateOrder(orderNumber, "test01", "test02", totalDue, orderLines);
                }
                catch (Exception e)
                {
                    Assert.Equal(e.Message, $"Invalid pricing data. Total amount: {totalDue}. Items amount: {(decimal)priceDue.Sum()}");
                }
            }


        }

        [Theory]
        [InlineData(true, "123456789")]
        [InlineData(false, "123456789")]
        public void Test_CancelOrder(bool isCancel, string orderNumber)
        {
            IUvsAdapter uvsAdapter = new UvsAdapter();

            if (uvsAdapter.IsOrderCanceled(orderNumber))
            {
                return;
            }

            if (isCancel)
            {
                uvsAdapter.CancelOrder(orderNumber);
            }

            var result = uvsAdapter.IsOrderCanceled(orderNumber);

            Assert.Equal(isCancel, result);
        }

        [Theory]
        [InlineData("123456789")]
        public void Test_Payment(string orderNumber)
        {
            IUvsAdapter uvsAdapter = new UvsAdapter();

            var result = uvsAdapter.ConfirmPayment(orderNumber);

            Assert.Equal(result, false);
        }
    }
}
