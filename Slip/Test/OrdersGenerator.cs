using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.SlipTest
{
    public class OrdersGenerator
    {
        static public IEnumerable<object[]> GetOrders()
        {
            yield return new object[] { new OrderBuilder().WithHeader("LRK0123456", "79261234567", "FooBar", Utils.Common.Business.Locale.Latvia)
                .WithObtainingMethod(Ordering.Abstractions.Enums.GoodsObtainingMethod.Dispensing)
                .WithItems(new OrderLine[] { OrderLine.Create("0141", 1, Money.Create(100m, CurrencyCode.Euro), Money.Create(100m, CurrencyCode.Euro)) })
                .WithTotalAmount(Money.Create(100m, CurrencyCode.Euro)).Build() };
        }
    }
}
