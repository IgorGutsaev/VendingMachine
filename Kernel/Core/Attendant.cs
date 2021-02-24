using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions.Enums;
using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions;
using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions.Enums;
using Filuet.ASC.OnBoard.Kernel.Core.Events;
using Filuet.ASC.OnBoard.Payment.Abstractions;
using Filuet.Utils.Common.Business;
using Filuet.Utils.Extensions;
using System;

namespace Filuet.ASC.OnBoard.Kernel.Core
{
    public class Attendant : IAttendant
    {
        public Attendant(IPaymentProvider paymentService, ICompositeDispenser dispenser, ISlipService slipService)
        {
            _paymentService = paymentService;
            _dispenser = dispenser;
            _slipService = slipService;

            _paymentService.OnTotalAmountCollected += (sender, e) =>
            {
                if (e.ChangeToIssue > 0m) // && cash payment only (probably)
                    GiveChange(e.ChangeToIssue);
                else _slipService.Print(Order, SlipType.Standard);
            };

            _paymentService.OnTotalChangeHasBeenGiven += (sender, e) =>
            {
                if (Order.Obtaining == GoodsObtainingMethod.Warehouse)
                    _slipService.Print(Order, SlipType.Standard);
                else if (Order.Obtaining == GoodsObtainingMethod.Dispensing)
                    Dispense();
            };
        }

        public void StartOrder(Action<OrderBuilder> setupOrder)
        {
            ChangeState(AttendantState.Busy);
            Order = setupOrder?.CreateTargetAndInvoke().Build();

            TraceState.SetOrderNumber(Order.Number);

            if (Order.Obtaining == GoodsObtainingMethod.Dispensing && _dispenser == null)
            {
                CompleteOrder();
                throw new Exception("Unable to find a dispenser");
            }
        }

        /// <summary>
        /// Change to be issued in the order context
        /// </summary>
        /// <param name="change"></param>
        private void GiveChange(Money change) => _paymentService.GiveChange(change);

        public void CompleteOrder() => Flush();

        private void Flush()
        {
            OnOrderCompleted?.Invoke(this, new OrderCloseEventArgs { Order = _order });
            _order = null;
            TraceState.FlushOrderNumber();
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

        private void Dispense()
        {
            _dispenser.Dispense(Order.Items);
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

        public event EventHandler<OrderOpenEventArgs> OnOrderOpened;

        public event EventHandler<IncomePaymentEventArgs> OnIncomePayment;

        public event EventHandler<OrderCloseEventArgs> OnOrderCompleted;

        public event EventHandler<AttendantStateEventArgs> OnAttendantStateChanged;

        private readonly IPaymentProvider _paymentService;
        private readonly ICompositeDispenser _dispenser;
        private readonly ISlipService _slipService;
    }
}