using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions
{
    public interface IStorageService
    {
        void Add(Planogram planogram);

        IEnumerable<Planogram> Get(Expression<Func<Planogram, bool>> planogram);

        void Truncate();

        int Count();
        void AddCashPaymentDetails(CashPaymentDetail detail);
        IEnumerable<CashPaymentDetail> GetCashPaymentDetails(Expression<Func<CashPaymentDetail, bool>> detail);
    }
}
