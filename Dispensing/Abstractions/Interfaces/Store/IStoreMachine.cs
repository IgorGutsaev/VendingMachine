using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces
{
    public interface IStoreMachine<TTray, TBelt> : IStoreUnit
        where TTray : IStoreTray<TBelt>, new()
        where TBelt : IStoreBelt, new()
    {
        IEnumerable<TTray> Trays { get; }

        TTray AddTray(uint number);
    }
}
