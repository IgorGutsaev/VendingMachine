using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Core
{
    public class CashPaymentService : ICashPaymentService
    {
        public CashPaymentService() { }

        //public void ReduceDuty(Money money)
        //{
        //    CashDevice.ReduceDuty(money);
        //}

        public void IssueChange(Money money)
        {
          //  CashDevice.GiveChange(money);
        }

        //public void AppendCashDevice(ICashDeviceAdapter cashDevice)
        //{
        //    CashDevice = cashDevice;

        //    CashDevice.OnChangeIssued += CashDevice_OnChange;
        //    CashDevice.OnReceive += CashDevice_OnReceive;
        //    CashDevice.OnStop += CashDevice_OnStopDevice;
        //    CashDevice.OnTest += CashDevice_OnTest;
        //}

        private void CashDevice_OnTest(object sender, TestResultCash e)
        {
            throw new NotImplementedException();
        }

        private void CashDevice_OnStopDevice(object sender, StopCashDeviceEventArgs e)
        {
            OnStop?.Invoke(this, e);
        }

        private void CashDevice_OnReceive(object sender, CashIncomeEventArgs e)
        {
            OnReceived?.Invoke(this, e);
        }

        private void CashDevice_OnChange(object sender, CashIncomeEventArgs e)
        {
            OnGivedChange?.Invoke(this, e);
        }

        //public void RemoveCashDevice()
        //{
        //    CashDevice.OnChangeIssued -= CashDevice_OnChange;
        //    CashDevice.OnReceive -= CashDevice_OnReceive;
        //    CashDevice.OnStop -= CashDevice_OnStopDevice;
        //    CashDevice.OnTest -= CashDevice_OnTest;

        //    _cashDevice = null;
        //}

        public void Stop()
        {
            //CashDevice.StopPayment();
        }


        public IEnumerable<ICashDeviceAdapter> CashDevices { get; set; }

        public event EventHandler<CashIncomeEventArgs> OnReceived;
        public event EventHandler<CashIncomeEventArgs> OnGivedChange;
        public event EventHandler<StopCashDeviceEventArgs> OnStop;
    }
}
