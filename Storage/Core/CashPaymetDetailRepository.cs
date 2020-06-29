using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Core
{
    public class CashPaymetDetailRepository : AscBaseRepository<LocalStorageContext, CashPaymentDetail>, ICashPaymentDetailRepository
    {
        public CashPaymetDetailRepository(LocalStorageContext dbContext): base(dbContext)
        {
        }

        public override void Add(IEnumerable<CashPaymentDetail> details)
        {
            if (DbContext.MaxDBSizeExceeded())
                throw new LocalStorageException("Database size exceeded maximum size limit.");

            base.Add(details);
        }
    }
}
