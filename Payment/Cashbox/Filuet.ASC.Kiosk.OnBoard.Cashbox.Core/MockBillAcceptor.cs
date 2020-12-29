using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.ASC.OnBoard.Payment.Abstractions.Interfaces;
using Filuet.Utils.Common.Business;
using Filuet.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Core
{
    public class MockBillAcceptor : ICashDeviceAdapter
    {
        public uint IssueIndex => _settings.IssueIndex;

        public MockBillAcceptor(ICurrencyConverter currencyConverter, Action<CashHandleSettings> setupAction)
        {
            _currencyConverter = currencyConverter;
            _settings = setupAction?.CreateTargetAndInvoke();
        }

        public void ReduceOrSetDutyTo(Money money)
        {
            if (money < 0) 
                throw new ArgumentException("Invalid amount of money to collect");

            _upperThresholdToCollect = money;
        }

        public (Money change, Money nativeChange) GiveChange(Money change)
        {
            Thread.Sleep(100);

            var changeNominals = SortedBillsFromTheBiggestToTheSmallest(_settings.BaseCurrency, false);
            Money theBiggestBill = changeNominals.FirstOrDefault(x => x.Value <= change.Value).Key;

            if (theBiggestBill != null)
            {
                Money nativeChange = _currencyConverter.Convert(theBiggestBill, _settings.BaseCurrency);
                OnSomeChangeIssued?.Invoke(this, CashIssueEventArgs.BillIncome(MoneyNaturalized.Create(nativeChange, theBiggestBill)));
                return (theBiggestBill, nativeChange);
            }

            return (null, null);
        }

        public void Start()
        {
            Money duty = null;

            while (true)
            {
                duty = Money.From(_upperThresholdToCollect); // _upperThresholdToCollect is renewable so we have to check it every time
                Thread.Sleep(100);
                Money bill = MakeFakeSingleBillIncome(duty); // Collected bill at this step
                Money nativeAmount = _currencyConverter.Convert(bill, duty.Currency);

                if (duty == nativeAmount || duty < bill)
                {
                    duty = Money.Create(0m, duty.Currency);
                    break;
                }
                else duty -= _currencyConverter.Convert(bill, duty.Currency);
            }
        }

        private Money MakeFakeSingleBillIncome(Money amount)
        {
            if (_settings.BillsToReceive == null || !_settings.BillsToReceive.Any())
                throw new Exception("There is no bills related to the device");

            var receiveNominals = SortedBillsFromTheBiggestToTheSmallest(amount.Currency);
            Money theBiggestBill = receiveNominals.FirstOrDefault(x => x.Value <= amount.Value).Key;
            if (theBiggestBill == null)
                theBiggestBill = receiveNominals.Last().Key;

            OnMoneyReceived?.Invoke(this, CashIncomeEventArgs.BillIncome(MoneyNaturalized.Create(_currencyConverter.Convert(theBiggestBill, amount.Currency), theBiggestBill)));

            return theBiggestBill;
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void StopPayment()
        {
            _upperThresholdToCollect = null;
        }

        public void Test()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<KeyValuePair<Money, decimal>> SortedBillsFromTheBiggestToTheSmallest(CurrencyCode currency, bool receiveBills = true)
            => (receiveBills ? _settings.BillsToReceive : _settings.BillsToGiveChange).Select(x => new KeyValuePair<Money, decimal>(x, _currencyConverter.Convert(x, currency).Value)).OrderByDescending(x => x.Value);

        public event EventHandler<CashIncomeEventArgs> OnMoneyReceived;
        public event EventHandler<TestResultCash> OnTest;
        public event EventHandler<CashIssueEventArgs> OnSomeChangeIssued;
        public event EventHandler<StopCashDeviceEventArgs> OnStop;
        public event EventHandler<StartCashDeviceEventArgs> OnStart;

        private readonly ICurrencyConverter _currencyConverter;
        private readonly CashHandleSettings _settings;
        private Money _upperThresholdToCollect = null;
    }
}