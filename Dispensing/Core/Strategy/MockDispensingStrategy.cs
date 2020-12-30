using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities.Dispensing;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Core.Strategy
{
    internal class MockDispensingStrategy : IDispensingStrategy
    {
        public MockDispensingStrategy(ILayout layout)
        {
            _layout = layout;
        }

        public IEnumerable<DispenseCommand> BuildDispensingChain(IEnumerable<OrderItem> cart)
        {
            throw new NotImplementedException();
        }

        private readonly ILayout _layout;
    }
}
