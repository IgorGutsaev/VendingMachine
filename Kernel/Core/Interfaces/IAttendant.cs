using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.ASC.OnBoard.Kernel.Core.Events;
using Filuet.ASC.OnBoard.Payment.Abstractions;
using System;

namespace Filuet.ASC.OnBoard.Kernel.Core
{
    /// <summary>
    /// An orchestrator of the ordering process
    /// </summary>
    public interface IAttendant
    {
        event EventHandler<OrderOpenEventArgs> OnOrderOpened;
        event EventHandler<OrderCloseEventArgs> OnOrderCompleted;
        event EventHandler<AttendantStateEventArgs> OnAttendantStateChanged;
        event EventHandler<OrderSlipEventArgs> OnSlipPrinted;

        /// <summary>
        /// An event to log any full OR partial payment income via one of the channels (cash, card...)
        /// </summary>
        event EventHandler<SomeMoneyIncomeEventArgs> OnIncomePayment;
        /// <summary>
        /// When the change is given
        /// </summary>
        event EventHandler<SomeChangeIssuedEventArgs> OnIssueMoney;
        /// <summary>
        /// Raises after the attendant received accurate or superior price of the order
        /// </summary>
        event EventHandler<PaymentCollectedEventArgs> OnMoneyAcceptanceIsOver;
        event EventHandler<TotalChangeIssuedEventArgs> OnTotalChangeIssued;

        void StartOrder(Action<OrderBuilder> setupOrder);

        void CompleteOrder(/* STATUS    void CancelOrder(); //abnormal finalizing */);

        /// <summary>
        /// Vendor state <see cref="AttendantState"/>
        /// </summary>
        AttendantState State { get; }

        Order Order { get; }
    }
}