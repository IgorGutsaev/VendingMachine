using Filuet.ASC.Kiosk.OnBoard.Cashless.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashless.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.Cashless.Core
{
    public class CardPaymentService : ICardPaymentService
    {
        private ICardDeviceAdapter _cardDevice;

        public event EventHandler<StopCardEventArgs> OnStop;
        public event EventHandler<CardEventArgs> OnPayment;
        public event EventHandler<CardEventArgs> OnReturnPayment;
        


        private ICardDeviceAdapter CardDevice
        {
            get 
            {
                if (_cardDevice == null)
                {
                    throw new ArgumentException("CardPaymnetService has not CardDevice", "CardDevice");
                }
                return _cardDevice; 
            }
            set 
            {
                if (value == null)
                    throw new ArgumentException("CardDevice is null", "CardDevice");

                _cardDevice = value; 
            }
        }

        public CardPaymentService()
        {

        }

        private void CardDevice_OnTest(object sender, TestCardEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CardDevice_OnStopDevice(object sender, StopCardEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CardDevice_OnReturnPayment(object sender, CardEventArgs e)
        {
            OnReturnPayment?.Invoke(this, e);
        }

        private void CardDevice_OnStopPayment(object sender, StopCardEventArgs e)
        {
             OnStop?.Invoke(this, e);
        }

        private void CardDevice_OnStartPayment(object sender, CardEventArgs e)
        {
             OnPayment?.Invoke(this, e);
        }

        public void AddCardDevice(ICardDeviceAdapter cardDevice)
        {
            CardDevice = cardDevice;

            CardDevice.OnPayment += CardDevice_OnStartPayment;
            CardDevice.OnStopPayment += CardDevice_OnStopPayment;
            CardDevice.OnReturnPayment += CardDevice_OnReturnPayment;
            CardDevice.OnStopDevice += CardDevice_OnStopDevice;
            CardDevice.OnTest += CardDevice_OnTest;
        }

        public void RemoveCardDevice()
        {

            CardDevice.OnPayment -= CardDevice_OnStartPayment;
            CardDevice.OnStopPayment -= CardDevice_OnStopPayment;
            CardDevice.OnReturnPayment -= CardDevice_OnReturnPayment;
            CardDevice.OnStopDevice -= CardDevice_OnStopDevice;
            CardDevice.OnTest -= CardDevice_OnTest;

            _cardDevice = null;
        }

        public void StopPayment()
        {
            CardDevice.StopPayment();
        }

        public void StartPayment(Money money)
        {

            CardDevice.StartPayment(money);
        }

        public void StartReturnPayment(Money money)
        {
            CardDevice.StartReturnPayment(money);
        }
    }
}
