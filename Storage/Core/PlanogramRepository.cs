using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Core
{
    public class PlanogramRepository : AscBaseRepository<LocalStorageContext, Planogram>, IPlanogramRepository
    {
        public PlanogramRepository(LocalStorageContext dbContext) : base(dbContext)
        { }

        public override void Add(IEnumerable<Planogram> entities)
        {
            if (DbContext.MaxDBSizeExceeded())
                throw new LocalStorageException("Database size exceeded maximum size limit.");

            base.Add(entities);
        }
    }
}
