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
        /// A change to dispense
        /// </summary>
        Money Change { get; }

        event EventHandler<MoneyEventArgs> OnAmountSpecified;

        /////// <summary>
        /////// When requested summ finally collected
        /////// </summary>
        ////event EventHandler<Money> OnCollected;

        /////// <summary>
        /////// When collection process consists of several deposits
        /////// </summary>
        ////event EventHandler<Money> OnRefund;

        /////// <summary>
        /////// When refund summ is completely refunded
        /////// </summary>
        ////event EventHandler<Money> OnRefunded;

        ////event EventHandler<string> OnError;

        /// <summary>
        /// Collect summ
        /// </summary>
        /// <param name="money">Due</param>
        /// <param name="setupAction">To pass some payment payload- timeout, installments etc</param>
        /// <returns></returns>
        bool Collect(Money money, Action<IPaymentProvider> setupAction);

        void OnMoneyIncome(Money money);
    }
}