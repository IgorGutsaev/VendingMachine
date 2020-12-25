using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.ASC.OnBoard.Payment.Abstractions.Interfaces;
using Filuet.Utils.Common.Business;
using Filuet.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Core
{
    public class MockBillAcceptor : ICashDeviceAdapter
    {
        public MockBillAcceptor(ICurrencyConverter currencyConverter, Action<BillAcceptanceSettings> setupAction)
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

        public void GiveChange(Money money)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            Money duty = null;

            while (true)
            {
                duty = Money.From(_upperThresholdToCollect);
                Thread.Sleep(100);
                Money bill = MakeFakeSingleBillIncome(duty); // Collected bill at this step
                Money nativeBill = _currencyConverter.Convert(bill, duty.Currency);

                if (duty == nativeBill || duty < bill)
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

            var bills = _settings.BillsToReceive.Select(x => new KeyValuePair<Money, decimal>(x, _currencyConverter.Convert(x, amount.Currency).Value)).OrderByDescending(x => x.Value);
            Money theBiggestBill = bills.FirstOrDefault(x => x.Value <= amount.Value).Key;
            if (theBiggestBill == null)
                theBiggestBill = bills.Last().Key;

            OnMoneyReceived?.Invoke(this, CashIncomeEventArgs.BillIncome(theBiggestBill, _currencyConverter.Convert(theBiggestBill, amount.Currency)));

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

        public event EventHandler<CashIncomeEventArgs> OnMoneyReceived;
        public event EventHandler<TestResultCash> OnTest;
        public event EventHandler<CashIncomeEventArgs> OnChangeIssued;
        public event EventHandler<StopCashDeviceEventArgs> OnStop;
        public event EventHandler<StartCashDeviceEventArgs> OnStart;

        private readonly ICurrencyConverter _currencyConverter;
        private readonly BillAcceptanceSettings _settings;
        private Money _upperThresholdToCollect = null;
    }
}
