using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Tests.Entities;
using System;
using Xunit;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Tests
{
    public class MachineTest : BaseTest
    {
        [Fact]
        public void Test_Construct_Machine_With_Builder()
        {
            // Prepare
            IStoreMachine<BarStoreTray, BazStoreBelt> machine = GetMachine<BarStoreTray, BazStoreBelt>((b) => b.AddTray(2)
                .AddTray(3)
                .AddBelt(1, 1)
                .AddBelt(1, 2));

            // Pre-validation
            Assert.NotNull(machine);

            // Perform

            // Post-validation
        }
    }
}
