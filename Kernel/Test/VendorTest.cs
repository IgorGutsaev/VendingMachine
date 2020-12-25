using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions;
using Filuet.ASC.OnBoard.Kernel.Core;
using Filuet.Utils.Common.Business;
using System;
using Xunit;

namespace Filuet.ASC.OnBoard.Kernel.Test
{
    public class VendorTest : BaseTest
    {
        [Fact]
        public void Test_Vendor_Create()
        {
            // Prepare
            IAttendant vendor = GetAttendant();

            // Validate
            Assert.NotNull(vendor);
        }

        [Theory]
        [InlineData("foo", 1, 0)]
        public void Test_StartOrder(string productId, uint qty, decimal amount)
        {
            // Prepare
            IAttendant vendor = GetAttendant();
            Money money = Money.Create(amount, Currency);

            // Perform
            vendor.StartOrder(b => b.WithItems(OrderLine.Create(productId, qty, money, Money.Create(qty * amount, Currency)))
                .WithTotalAmount(money));

            // Post-validate
            Assert.NotNull(vendor.Order);
            Assert.NotEqual(Guid.Empty, vendor.Order.Id);
        }
    }
}
