using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Core
{
    public class CashPaymentService : ICashPaymentService
    {    
        ICashDeviceAdapter _cashDevice;

        public event EventHandler<CashEventArgs> OnGoodReceived;
        public event EventHandler<CashEventArgs> OnBadReceived;
        public event EventHandler<CashEventArgs> OnGoodGivedChange;
        public event EventHandler<CashEventArgs> OnBadGivedChange;
        public event EventHandler<StopCashEventArgs> OnGoodStop;
        public event EventHandler<StopCashEventArgs> OnBadStop;

        private ICashDeviceAdapter CashDevice 
        { 
            get
            {
                if (_cashDevice == null)
                {
                    throw new ArgumentException("CashPaymnetService has not CashDevice", "CashDevice");
                }

                return _cashDevice;
            }
            set 
            {
                if (value == null)
                    throw new ArgumentException("CashDevice is null", "CashDevice");

                _cashDevice = value;
            } 
        }        


        public CashPaymentService()
        {

        }


        public void CashReceive(Money money)
        {
            CashDevice.CashReceive(money);
        }

        public void GiveChange(Money money)
        {
            CashDevice.GiveChange(money);
        }

        public void AddCashDevice(ICashDeviceAdapter cashDevice)
        {
            CashDevice = cashDevice;

            CashDevice.OnChange += CashDevice_OnChange;
            CashDevice.OnReceive += CashDevice_OnReceive;
            CashDevice.OnStopDevice += CashDevice_OnStopDevice;
            CashDevice.OnStopPayment += CashDevice_OnStopPayment;
            CashDevice.OnTest += CashDevice_OnTest;
        }

        private void CashDevice_OnTest(object sender, TestResultCash e)
        {
            throw new NotImplementedException();
        }

        private void CashDevice_OnStopPayment(object sender, StopCashEventArgs e)
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

        private void CashDevice_OnStopDevice(object sender, StopCashEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CashDevice_OnReceive(object sender, CashEventArgs e)
        {
            if (e.Event.IsError)
            {
                OnBadReceived?.Invoke(this, e);
            }
            else
            {
                OnGoodReceived?.Invoke(this, e);
            }
        }

        private void CashDevice_OnChange(object sender, CashEventArgs e)
        {
            if (e.Event.IsError)
            {
                OnBadGivedChange?.Invoke(this, e);
            }
            else
            {
                OnGoodGivedChange?.Invoke(this, e);
            }
        }

        public void RemoveCashDevice()
        {
            CashDevice.OnChange -= CashDevice_OnChange;
            CashDevice.OnReceive -= CashDevice_OnReceive;
            CashDevice.OnStopDevice -= CashDevice_OnStopDevice;
            CashDevice.OnStopPayment -= CashDevice_OnStopPayment;
            CashDevice.OnTest -= CashDevice_OnTest;

            _cashDevice = null;
        }

        public void Stop()
        {
            CashDevice.StopPayment();
        }
    }
}
