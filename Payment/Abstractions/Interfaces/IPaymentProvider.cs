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
        Money Duty { get; } // = |Amount - Credit|

        /// <summary>
        /// A change to issue
        /// </summary>
        Money Change { get; }

        /// <summary>
        /// Actually issued change
        /// </summary>
        Money ChangeIssued { get; }

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
        event EventHandler<TotalChangeIssuedEventArgs> OnTotalChangeBeenGiven;

        /// <summary>
        /// Collect summ
        /// </summary>
        /// <param name="money">Due</param>
        /// <param name="setupAction">To pass some payment payload- timeout, installments etc</param>
        /// <returns></returns>
        bool Collect(Money money, Action<IPaymentProvider> setupAction);

        void WhenSomeMoneyIncome(Money money);

        void GiveChange(Money change);

        void WhenSomeChangeExtracted(Money changeIssued);
    }
}