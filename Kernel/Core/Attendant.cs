using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions;
using Filuet.Utils.Extensions;
using System;

namespace Filuet.ASC.OnBoard.Kernel.Core
{
    public class Attendant : IAttendant
    {
        /// <summary>
        /// Vendor state <see cref="AttendantState"/>
        /// </summary>
        public AttendantState State { get; private set; } = AttendantState.Idle;

        public Order Order
        {
            get => _order;
            set {
                _order = value;
                OnNewOrder?.Invoke(this, new NewOrderEventArgs { Order = _order });
            }
        }

        public event EventHandler<NewOrderEventArgs> OnNewOrder;

        private static Attendant Vendor { get; set; }

        static Attendant()
        {
            Vendor = new Attendant();
        }

        public void StartOrder(Action<OrderBuilder> setupOrder)
        {
            State = AttendantState.Busy;
            Order = setupOrder?.CreateTargetAndInvoke().Build();
        }

        public void Flush()
        {
            Order = null;
            State = AttendantState.Idle;
        }

        private Order _order;
    }
}