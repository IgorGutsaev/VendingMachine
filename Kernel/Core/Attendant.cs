using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions;
using Filuet.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.OnBoard.Kernel.Core
{
    public class Attendant
    {
        public AttendantState State { get; private set; } = AttendantState.Idle;
        public Order Order { get; private set; }

        public event EventHandler<Order> OnNewOrder;

        private static Attendant Vendor { get; set; }

        static Attendant()
        {
            Vendor = new Attendant();
        }

        public void StartOrder(Action<OrderBuilder> setupOrder)
        {
            State = AttendantState.Busy;
            Order = setupOrder?.CreateTargetAndInvoke().Build();
            OnNewOrder?.Invoke(this, Order);
        }

        public void Flush()
        {
            Order = null;
            State = AttendantState.Idle;
        }
    }
}
