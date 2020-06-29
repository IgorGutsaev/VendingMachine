using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions;
using System;

namespace Filuet.ASC.OnBoard.Kernel.Core
{
    public interface IAttendant
    {
        event EventHandler<NewOrderEventArgs> OnNewOrder;

        /// <summary>
        /// Vendor state <see cref="AttendantState"/>
        /// </summary>
        AttendantState State { get; }

        Order Order { get;}

        void StartOrder(Action<OrderBuilder> setupOrder);

        void Flush();
    }
}