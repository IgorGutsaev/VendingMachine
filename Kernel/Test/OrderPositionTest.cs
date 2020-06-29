using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Filuet.ASC.OnBoard.Kernel.Test
{
    public class OrderPositionTest : BaseTest
    {
        [Theory]
        [InlineData("foo", 1, 0)]
        public void Test_Create_Valid(string productId, uint qty, decimal amount)
        {
            // Prepare
            Money money = Money.Create(amount, Currency);

            // Pre-validate
            Assert.False(string.IsNullOrWhiteSpace(productId));
            Assert.True(qty > 0);
            Assert.True(amount >= 0);

            // Perform
            OrderPosition result = OrderPosition.Create(productId, qty, money);

            // Post-validate
            Assert.NotNull(result);
            Assert.NotNull(result.Amount);
            Assert.Equal(amount, result.Amount.Value);
            Assert.Equal(productId, result.Product);
            Assert.Equal(qty, result.Quantity);
        }
    }
}
