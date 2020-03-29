using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Core
{
    public class AscBaseUnitOfWork : AscUnitOfWork<LocalStorageContext>
    {
        public AscBaseUnitOfWork(LocalStorageContext context)
           : base(context)
        { }
    }
}
