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

        public event EventHandler<MoneyEventArgs> OnAmountSpecified;

        ////public event EventHandler<Money> OnCollected;
        ////public event EventHandler<Money> OnRefund;
        ////public event EventHandler<Money> OnRefunded;
        ////public event EventHandler<string> OnError;

        public bool Collect(Money money, Action<IPaymentProvider> setupAction)
        {
            Amount = Money.From(money);
            Duty = Money.From(money);
            Credit = Money.Create(0m, money.Currency);
            Change = Money.Create(0m, money.Currency);

            OnAmountSpecified?.Invoke(this, new MoneyEventArgs { Value = money });
            return true;
        }

        public void OnMoneyIncome(Money money)
        {
            Credit += money;
            if (Credit >= Amount)
            {
                Duty = Money.Create(0m, Amount.Currency);
                Change = Credit > Amount ? Credit - Amount : Money.Create(0m, Amount.Currency);
            }
            else Duty -= money;
        }
    }
}
