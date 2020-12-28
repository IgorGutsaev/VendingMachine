using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions;
using Filuet.ASC.OnBoard.Kernel.Core.Events;
using System;

namespace Filuet.ASC.OnBoard.Kernel.Core
{
    /// <summary>
    /// An orchestrator of the ordering process
    /// </summary>
    public interface IAttendant
    {
        void StartOrder(Action<OrderBuilder> setupOrder);

        void PrintReceipt();

        void CompleteOrder(/* STATUS    void CancelOrder(); //abnormal finalizing */);

        event EventHandler<AttendantStateEventArgs> OnAttendantStateChanged;

        event EventHandler<OrderEventArgs> OnOrderOpened;

        event EventHandler<OrderEventArgs> OnOrderCompleted;

        /// <summary>
        /// An event to log any payment income via one of the channels (cash, card...)
        /// </summary>
        event EventHandler<IncomePaymentEventArgs> OnIncomePayment;

        /// <summary>
        /// Vendor state <see cref="AttendantState"/>
        /// </summary>
        AttendantState State { get; }

        Order Order { get; }
    }
}