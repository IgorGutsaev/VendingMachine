using Filuet.ASC.Kiosk.OnBoard.UVS.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Xunit;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Tests
{
    public class MockUvsTest
    {
        [Fact]
        public void Test_Payment()
        {
            // Prepare
            MockUvsAdapter adapter = new MockUvsAdapter();
            string orderNumber = Guid.NewGuid().ToString();

            // Pre-validate

            // Perform
            //adapter.OnUvsPayment += (sender, e) =>
            //{

            //};

            adapter.CreateOrder(orderNumber, "foo", "bar", 100m, null);

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                if (adapter.ConfirmPayment(orderNumber))
                    break;
            }

            // Post-validate
            Assert.True(adapter.ConfirmPayment(orderNumber));
        }
    }
}
