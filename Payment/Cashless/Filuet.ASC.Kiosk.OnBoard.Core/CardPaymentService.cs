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

        public event EventHandler<StopCardEventArgs> OnGoodStop;
        public event EventHandler<StopCardEventArgs> OnBadStop;
        public event EventHandler<CardEventArgs> OnGoodPayment;
        public event EventHandler<CardEventArgs> OnBadPayment;
        public event EventHandler<CardEventArgs> OnGoodReturnPayment;
        public event EventHandler<CardEventArgs> OnBadReturnPayment;   
        
        private enum TypePayment
        {
            Payment,
            ReturnPayment
        }

        private TypePayment _currentTypePayment;

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
            if (e.Event.IsError)
            {
                OnBadReturnPayment?.Invoke(this, e);
            }
        }

        private void CardDevice_OnFinishedPayment(object sender, CardEventArgs e)
        {
            switch (_currentTypePayment)
            {
                case TypePayment.Payment:
                    if (e.Event.IsError)
                    {
                        OnBadPayment?.Invoke(this, e);
                    }
                    else
                    {
                        OnGoodPayment?.Invoke(this, e);
                    }
                    break;
                case TypePayment.ReturnPayment:
                    if (e.Event.IsError)
                    {
                        OnBadReturnPayment?.Invoke(this, e);
                    }
                    else
                    {
                        OnGoodReturnPayment?.Invoke(this, e);
                    }
                    break;
            }

        }

        private void CardDevice_OnStopPayment(object sender, StopCardEventArgs e)
        {
            if (e.Event.IsError)
            {
                OnBadStop?.Invoke(this, e);
            }
            else
            {
                OnGoodStop?.Invoke(this, e);
            }
        }

        private void CardDevice_OnStartPayment(object sender, CardEventArgs e)
        {
            if (e.Event.IsError)
            {
                OnBadPayment?.Invoke(this, e);
            }
        }

        public void AddCardDevice(ICardDeviceAdapter cardDevice)
        {
            CardDevice = cardDevice;

            CardDevice.OnStartPayment += CardDevice_OnStartPayment;
            CardDevice.OnStopPayment += CardDevice_OnStopPayment;
            CardDevice.OnFinishedPayment += CardDevice_OnFinishedPayment;
            CardDevice.OnReturnPayment += CardDevice_OnReturnPayment;
            CardDevice.OnStopDevice += CardDevice_OnStopDevice;
            CardDevice.OnTest += CardDevice_OnTest;
        }

        public void RemoveCardDevice()
        {

            CardDevice.OnStartPayment -= CardDevice_OnStartPayment;
            CardDevice.OnStopPayment -= CardDevice_OnStopPayment;
            CardDevice.OnFinishedPayment -= CardDevice_OnFinishedPayment;
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
            _currentTypePayment = TypePayment.Payment;

            CardDevice.StartPayment(money);
        }

        public void ReturnPayment(Money money)
        {
            _currentTypePayment = TypePayment.ReturnPayment;

            CardDevice.ReturnPayment(money);
        }
    }
}
