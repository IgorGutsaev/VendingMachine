using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions;
using Filuet.ASC.OnBoard.Kernel.Core.Events;
using Filuet.ASC.OnBoard.Payment.Abstractions;
using Filuet.Utils.Extensions;
using System;

namespace Filuet.ASC.OnBoard.Kernel.Core
{
    public class Attendant : IAttendant
    {
        public Attendant(IPaymentProvider paymentService)
        {
            _paymentService = paymentService;

            //_paymentService.OnReceived += (sender, e) =>
            //{

            //};
        }

        public void StartOrder(Action<OrderBuilder> setupOrder)
        {
            ChangeState(AttendantState.Busy);
            Order = setupOrder?.CreateTargetAndInvoke().Build();
        }

        public void CompleteOrder()
        {

            Flush();
        }

        private void Flush()
        {
            OnOrderCompleted?.Invoke(this, new OrderCloseEventArgs { Order = _order });
            _order = null;
            ChangeState(AttendantState.Idle);
        }

        private Order _order;

        private AttendantState _state;

        /// <summary>
        /// Vendor state <see cref="AttendantState"/>
        /// </summary>
        public AttendantState State => _state;

        private void ChangeState(AttendantState state)
        {
            OnAttendantStateChanged?.Invoke(this, new AttendantStateEventArgs { PreviousState = _state, State = state });
            _state = state;
        }

        public Order Order
        {
            get => _order;
            set
            {
                _order = value;

                OnOrderOpened?.Invoke(this, new OrderOpenEventArgs { Order = _order });
            }
        }

        public event EventHandler<OrderEventArgs> OnOrderOpened;
        public event EventHandler<IncomePaymentEventArgs> OnIncomePayment;
        public event EventHandler<OrderEventArgs> OnOrderCompleted;
        public event EventHandler<AttendantStateEventArgs> OnAttendantStateChanged;

        private readonly IPaymentProvider _paymentService;
    }
}