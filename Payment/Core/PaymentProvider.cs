using Filuet.ASC.OnBoard.Payment.Abstractions;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.OnBoard.Payment.Core
{
    public class PaymentProvider : IPaymentProvider
    {
        public PaymentProvider() { }

        public Money Amount { get; private set; }

        public Money Credit { get; private set; }

        public Money Duty { get; private set; }

        public Money Change { get; private set; }

        public Money ChangeIssued { get; private set; }

        public bool Collect(Money money, Action<IPaymentProvider> setupAction)
        {
            Amount = Money.From(money);
            Duty = Money.From(money);
            Credit = Money.Create(0m, money.Currency);
            Change = Money.Create(0m, money.Currency);

            OnTotalAmountSpecified?.Invoke(this, new TotalAmountSpecifiedEventArgs { Value = money });
            return true;
        }

        public void WhenSomeMoneyIncome(Money money)
        {
            Credit += money;
            if (Credit >= Amount)
            {
                Duty = Money.Create(0m, Amount.Currency);
                Change = Credit > Amount ? Credit - Amount : Money.Create(0m, Amount.Currency);

                OnTotalAmountCollected?.Invoke(this, PaymentCollectedEventArgs.Create(Credit, Change));
            }
            else Duty -= money;
        }

        public void GiveChange(Money change)
        {
            if (change > 0m)
                OnGiveChangeSpecified?.Invoke(this, GiveChangeEventArgs.Create(change));
        }

        public void WhenSomeChangeExtracted(Money changeIssued)
        {
            ChangeIssued += changeIssued;

            if ((ChangeIssued - Change).Abs < 0.01m || ChangeIssued >= Change)
                OnTotalChangeBeenGiven?.Invoke(this, TotalChangeIssuedEventArgs.Create(Change, ChangeIssued, Money.Create(0m, Change.Currency)));
        }

        /// <summary>
        /// When the provider finds out how much money needs to be collected
        /// </summary>
        public event EventHandler<TotalAmountSpecifiedEventArgs> OnTotalAmountSpecified;

        /// <summary>
        /// Called when the Attendant commands to issue the change
        /// </summary>
        public event EventHandler<GiveChangeEventArgs> OnGiveChangeSpecified;

        /// <summary>
        /// When total amount has been collected
        /// </summary>
        public event EventHandler<PaymentCollectedEventArgs> OnTotalAmountCollected;

        /// <summary>
        /// Called when the the change has been completely given
        /// </summary>
        public event EventHandler<TotalChangeIssuedEventArgs> OnTotalChangeBeenGiven;
    }
}
