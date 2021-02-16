using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities.Dispensing;
using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces
{
    public interface IDispensingStrategy
    {
        IEnumerable<DispenseCommand> BuildDispensingChain(IEnumerable<OrderItem> cart);
    }
}
