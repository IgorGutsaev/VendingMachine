using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions.Enums;
using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;

namespace Filuet.ASC.OnBoard.Kernel.Core
{
    /// <summary>
    /// A mediator that united key components of ordering process: <see cref="IAttendant"/>, <see cref="IStorageService"/> etc
    /// </summary>
    public class OrderingMediator
    {
        public OrderingMediator(IAttendant attendant, IStorageService storage)
        {
            _attendant = attendant;
            _storage = storage;

            _attendant.OnOrderOpened += (sender, e) => _storage.AddOrderEvent(OrderAction.Open, e.Order);
            _attendant.OnOrderCompleted += (sender, e) => _storage.AddOrderEvent(OrderAction.Complete, e.Order);
            _attendant.OnIncomePayment += (sender, e) => _storage.AddOrderEvent(_attendant.Order.Number, OrderAction.MoneyIncome, e);
            _attendant.OnMoneyAcceptanceIsOver += (sender, e) => _storage.AddOrderEvent(_attendant.Order.Number, OrderAction.MoneyAccepted, e); ;
            _attendant.OnSlipPrinted += (sender, e) => _storage.AddOrderEvent(e.Order, OrderAction.PrintSlip, e);
        }

        private readonly IAttendant _attendant;
        private readonly IStorageService _storage;
    }
}
