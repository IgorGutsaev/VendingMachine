using Filuet.ASC.OnBoard.Payment.Abstractions;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.OnBoard.Payment.Core
{
    public class PaymentProvider : IPaymentProvider
    {
        public PaymentProvider() { }

        /// <summary>
        /// Total order price
        /// </summary>
        public Money Amount { get; private set; }

        /// <summary>
        /// Credited money (100% in case of electronic payment. But it could change dynamically in case of cash payment)
        /// </summary>
        public Money Credit
        {
            get => _credit;
            set {
                _credit = value;

                if (_credit >= Amount)
                {
                    Change = _credit > Amount ? _credit - Amount : Money.Create(0m, Amount.Currency);
                    OnTotalAmountCollected?.Invoke(this, PaymentCollectedEventArgs.Create(_credit, Change));
                }
            }
        }

        /// <summary>
        /// Remaining duty
        /// </summary>
        public Money Duty => Amount - Credit + ChangeIssued;

        /// <summary>
        /// A change to issue
        /// </summary>
        public Money Change { get; private set; }

        /// <summary>
        /// Actually issued change
        /// </summary>
        public Money ChangeIssued {
            get => _changeIssued;
            set {
                _changeIssued = value;

                if ((_changeIssued - Change).Abs < 0.01m || _changeIssued >= Change)
                    OnTotalChangeHasBeenGiven?.Invoke(this, TotalChangeIssuedEventArgs.Create(Change, _changeIssued, Money.Create(0m, Change.Currency)));
            }
        }

        public bool Collect(Money money, Action<IPaymentProvider> setupAction)
        {
            Amount = Money.From(money);
            Credit = Money.Create(0m, money.Currency);
            Change = Money.Create(0m, money.Currency);

            OnTotalAmountSpecified?.Invoke(this, new TotalAmountSpecifiedEventArgs { Value = money });
            return true;
        }

        /// <summary>
        /// Called on any customer's credit (cash insert or card trassaction etc)  
        /// </summary>
        /// <param name="money"></param>
        public void SomeMoneyIncome(MoneyNaturalized money) => Credit += money.Native;

        public void GiveChange(Money change)
        {
            if (change > 0m)
                OnGiveChangeSpecified?.Invoke(this, GiveChangeEventArgs.Create(change));
        }

        /// <summary>
        /// Called when any part of the change has been given (a bill or a coin)
        /// </summary>
        /// <param name="someChangeIssued"></param>
        public void SomeChangeExtracted(MoneyNaturalized someChangeIssued)
        {
            OnSomeChangeHasBeenGiven?.Invoke(this, SomeChangeIssuedEventArgs.Create(someChangeIssued));
            ChangeIssued += someChangeIssued.Native;
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
        public event EventHandler<TotalChangeIssuedEventArgs> OnTotalChangeHasBeenGiven;

        public event EventHandler<SomeChangeIssuedEventArgs> OnSomeChangeHasBeenGiven;

        private Money _credit;

        private Money _changeIssued;
    }
}