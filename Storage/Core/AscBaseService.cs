using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Core
{
    public abstract class AscBaseService<TUnitOfWork> : IAscBaseService<TUnitOfWork>
        where TUnitOfWork : IAscUnitOfWork
    {
        protected TUnitOfWork _uow;

        public TUnitOfWork UnitOfWork { get { return _uow; } }

        public AscBaseService(TUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
