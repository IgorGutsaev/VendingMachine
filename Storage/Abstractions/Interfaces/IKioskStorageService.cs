using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions
{
    public interface IKioskStorageService : IDisposable
    {
        void Add(Planogram planogram);

        IEnumerable<Planogram> Get(Expression<Func<Planogram, bool>> planogram);

        void Truncate();

        int Count();
    }
}
