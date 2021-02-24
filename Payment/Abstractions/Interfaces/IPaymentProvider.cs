using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.OnBoard.Payment.Abstractions
{
    public interface IPaymentProvider
    {
        /// <summary>
        /// A total amount of money to collect
        /// </summary>
        Money Amount { get; } 

        /// <summary>
        /// An amount of inserted money
        /// </summary>
        Money Credit { get; }

        /// <summary>
        /// A remaining amount of money to collect
        /// </summary>
        Money Duty { get; }

        /// <summary>
        /// A change to issue
        /// </summary>
        Money Change { get; }

        /// <summary>
        /// Actually issued change
        /// </summary>
        Money ChangeIssued { get; }

        /// <summary>
        /// Collect summ
        /// </summary>
        /// <param name="paymentSource">How should money be taken</param>
        /// <param name="order">An order to be payed</param>
        /// <param name="setupAction">To pass some payment payload- timeout, installments etc</param>
        /// <returns></returns>
        /// <remarks>We have to transfer an order model rather than payment
        /// because some payment sources require the order payload (like UVS requires order items) </remarks>
        bool Collect(PaymentSource paymentSource, Order order, Action<IPaymentProvider> setupAction);

        void SomeMoneyIncome(MoneyNaturalized money);

        void GiveChange(Money change);

        void SomeChangeExtracted(MoneyNaturalized someChangeIssued);

        event EventHandler<TotalAmountSpecifiedEventArgs> OnTotalAmountSpecified;

        // <summary>
        // When requested summ finally collected
        // </summary>
        event EventHandler<PaymentCollectedEventArgs> OnTotalAmountCollected;

        /// <summary>
        /// Called when the Attendant commands to issue the change
        /// </summary>
        event EventHandler<GiveChangeEventArgs> OnGiveChangeSpecified;

        /// <summary>
        /// Called when the the change has completely been given
        /// </summary>
        event EventHandler<SomeChangeIssuedEventArgs> OnSomeChangeHasBeenGiven;

        /// <summary>
        /// Called when the the change has completely been given
        /// </summary>
        event EventHandler<TotalChangeIssuedEventArgs> OnTotalChangeHasBeenGiven;

        /// <summary>
        /// A command with a new order to be payed
        /// </summary>
        event EventHandler<FetchMoneyEventArgs> OnFetchMoneyCommand;
    }
}