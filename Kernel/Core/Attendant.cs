using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions;
using Filuet.ASC.OnBoard.Kernel.Core.Events;
using Filuet.ASC.OnBoard.Payment.Abstractions;
using Filuet.Utils.Common.Business;
using Filuet.Utils.Extensions;
using System;

namespace Filuet.ASC.OnBoard.Kernel.Core
{
    public class Attendant : IAttendant
    {
        public Attendant(IPaymentProvider paymentService)
        {
            _paymentService = paymentService;

            _paymentService.OnTotalAmountCollected += (sender, e) =>
            { 
                if (e.ChangeToIssue > 0m) // And the cash payment took place probably
                    GiveChange(e.ChangeToIssue);
                else PrintReceipt();
            };

            _paymentService.OnTotalChangeBeenGiven += (sender, e) =>
            {
                PrintReceipt();
            };
        }

        public void StartOrder(Action<OrderBuilder> setupOrder)
        {
            ChangeState(AttendantState.Busy);
            Order = setupOrder?.CreateTargetAndInvoke().Build();
        }

        public void PrintReceipt()
        {
            Console.WriteLine("==================");
            Console.WriteLine("==    RECEIPT   ==");
            Console.WriteLine("==================");
        }

        /// <summary>
        /// Change to be issued in the order context
        /// </summary>
        /// <param name="change"></param>
        private void GiveChange(Money change) => _paymentService.GiveChange(change);

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
            if (state != _state)
            {
                OnAttendantStateChanged?.Invoke(this, new AttendantStateEventArgs { PreviousState = _state, State = state });
                _state = state;
            }
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