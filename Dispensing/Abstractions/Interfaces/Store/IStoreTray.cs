using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces
{
    public interface IStoreTray<T> : IStoreUnit
        where T: IStoreBelt, new()
    {
        IEnumerable<T> Belts { get; }

        T AddBelt(uint number);
    }
}
