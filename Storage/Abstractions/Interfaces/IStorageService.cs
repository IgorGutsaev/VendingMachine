using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions.Enums;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions
{
    public interface IStorageService
    {
        void AddPlanogram(Planogram planogram);

        void AddOrderEvent(OrderAction action, Order order);

        void AddOrderEvent(string orderNumber, OrderAction action, object payload);

        IEnumerable<Planogram> Get(Expression<Func<Planogram, bool>> planogram);

        void Truncate();

        int Count();

        void AddCashPaymentDetails(CashPaymentDetail detail);

        IEnumerable<CashPaymentDetail> GetCashPaymentDetails(Expression<Func<CashPaymentDetail, bool>> detail);
    }
}
