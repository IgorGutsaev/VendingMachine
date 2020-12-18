using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
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
            ILayout machine = BuildLayout(s => 
                s.AddMachine<FooMachine>(1)
                    .AddTray(11)
                        .AddBelt(2).CommitTray()
                    .AddTray(18)
                        .AddBelt(0).AddBelt(1).AddBelt(2).AddBelt(3).AddBelt(4).AddBelt(5).CommitTray().CommitMachine()
                .AddMachine<QuuxMachine>(2)
                    .AddTray(11)
                        .AddBelt(0).AddBelt(1).AddBelt(2).AddBelt(3).AddBelt(4).CommitTray().CommitMachine().Build());

            // Pre-validation
            Assert.NotNull(machine);

            // Perform

            // Post-validation
        }
    }
}
