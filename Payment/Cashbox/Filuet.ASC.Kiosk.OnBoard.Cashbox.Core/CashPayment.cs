using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using Filuet.Utils.Extensions;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Core
{
    public class CashPayment : ICashPayment
    {
        public decimal Amount { get; set; }

        public event EventHandler<EventItem> OnBadCashAcceptance;
        public event EventHandler<EventItem> OnGoodCashAcceptance;
        public event EventHandler<EventItem> OnBadCashOut;
        

        ICashDeviceAdapter _cashDevice;

        public CashPayment(ICashDeviceAdapter cashDevice)
        {
            _cashDevice = cashDevice;

            _cashDevice.OnCashReceive += OnCashReceive;

            _cashDevice.OnTest += OnTest;
        }
        
        private void OnTest(object sender, TestResultCash e)
        {
            Console.WriteLine($"CashPayment.OnTest. Result {e.Result} {e.Result.GetDescription()}");
        }

        public CashPayment()
        {
        }

        private void OnCashReceive(object sender, EventCashReceive e)
        {
            Amount = e.Money.Value;

            //TODO:записать в базу
            Console.WriteLine($"CashPayment.OnCashReceive.Cash accept {e.Money.Value} {e.Money.Currency.GetDescription()}");
        }

        public void CashAcceptance()
        {
            throw new NotImplementedException();
        }

        public void CashAcceptance(Money money)
        {
            _cashDevice.CashAcceptance(money);

            Console.WriteLine($"CashPayment.CashAcceptance.Cash accept {money.Value} {money.Currency.GetDescription()}");
        }

        public void CashOut(Money money)
        {
            throw new NotImplementedException();
        }

        public void StopDevice()
        {
            throw new NotImplementedException();
        }

        public bool Test()
        {
            _cashDevice.Test();

            return true;
        }
    }
}
