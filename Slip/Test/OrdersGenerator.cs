using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.SlipTest
{
    public class OrdersGenerator
    {
        static public IEnumerable<object[]> GetOrders()
        {
            yield return new object[] { new OrderBuilder().WithHeader("LRK0123456", "79261234567", "FooBar", Locale.Latvia, Lang.En)
                .WithObtainingMethod(Ordering.Abstractions.Enums.GoodsObtainingMethod.Warehouse)
                .WithItems(new OrderLine[] { OrderLine.Create("0141", 1, Money.Create(100m, CurrencyCode.Euro), Money.Create(100m, CurrencyCode.Euro)) })
                .WithTotalValues(Money.Create(100m, CurrencyCode.Euro), 65.5m)
                .WithExtraData("Kiosk", "LVRIGAS3")
                .WithExtraData("SelectedMonth", new DateTime(2021, 2, 1)).Build() };
        }
    }
}
