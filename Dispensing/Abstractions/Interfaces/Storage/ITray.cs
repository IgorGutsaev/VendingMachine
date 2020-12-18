using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces
{
    public interface ITray : ILayoutUnit
    {
        IEnumerable<IBelt> Belts { get; }

        IBelt AddBelt<TBelt>(uint number)
            where TBelt : Belt, new();
    }
}
