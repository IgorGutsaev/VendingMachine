using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions
{
    public interface IAscCacheRepository<T> : IAscRepository
        where T : class
    {
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetAll();

        void Add(IEnumerable<T> entities);

        T Add(T entity);

        bool Truncate();

        bool Delete(T entity);
        bool Delete(IEnumerable<T> entities);

        int Count();
    }
}
