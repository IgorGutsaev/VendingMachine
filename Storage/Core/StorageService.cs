using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions.Enums;
using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Core
{
    public class StorageService : IStorageService
    {        
        public StorageService(IAscUnitOfWork uow) => _uow = uow;

        public void AddPlanogram(Planogram planogram) => PlanogramRepository.Add(planogram);

        public void AddOrderEvent(OrderAction action, Order.Abstractions.Order order) => OrderLogRepository.Add(OrderLog.Create(order.Number, action.GetDescription(), order.ToString()));

        public void AddOrderEvent(string orderNumber, OrderAction action, object payload) => OrderLogRepository.Add(OrderLog.Create(orderNumber, action.GetDescription(), payload.ToString()));

        public void AddCashPaymentDetails(CashPaymentDetail detail) => CashPaymentDetailRepository.Add(detail);

        public void Truncate() => PlanogramRepository.Truncate();

        public int Count() => PlanogramRepository.Count();

        public IEnumerable<Planogram> Get(Expression<Func<Planogram, bool>> planogram)
            => PlanogramRepository.Get(planogram).AsEnumerable();

        public IEnumerable<CashPaymentDetail> GetCashPaymentDetails(Expression<Func<CashPaymentDetail, bool>> detail)
            => CashPaymentDetailRepository.Get(detail).AsEnumerable();

        public void Dispose() => _uow.Dispose();

        public override string ToString() => "SQLiteDB";

        protected IAscUnitOfWork _uow;

        private IPlanogramRepository _planogramRepository;

        private IOrderLogRepository _orderLogRepository;

        private ICashPaymentDetailRepository _cashPaymentDetailRepository;

        protected IPlanogramRepository PlanogramRepository =>
            _planogramRepository ?? (_planogramRepository = new PlanogramRepository((LocalStorageContext)_uow?.GetContext()));

        protected IOrderLogRepository OrderLogRepository =>
            _orderLogRepository ?? (_orderLogRepository = new OrderLogRepository((LocalStorageContext)_uow?.GetContext()));

        protected ICashPaymentDetailRepository CashPaymentDetailRepository =>
            _cashPaymentDetailRepository ?? (_cashPaymentDetailRepository = new CashPaymetDetailRepository((LocalStorageContext)_uow?.GetContext()));
    }
}
