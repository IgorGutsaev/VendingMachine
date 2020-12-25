using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Core
{
    public class OrderLogRepository : AscBaseRepository<LocalStorageContext, OrderLog>, IOrderLogRepository
    {
        public OrderLogRepository(LocalStorageContext dbContext) : base(dbContext)
        { }

        public override void Add(IEnumerable<OrderLog> entities)
        {
            if (DbContext.MaxDBSizeExceeded())
                throw new LocalStorageException("Database size exceeded maximum size limit.");

            base.Add(entities);
        }
    }
}
