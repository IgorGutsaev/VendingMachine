using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions
{
    public interface IAscBaseService<TUnitOfwork>
        where TUnitOfwork : IAscUnitOfWork
    {
        TUnitOfwork UnitOfWork { get; }
    }
}
