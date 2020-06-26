using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Core
{
    public class CashPaymentService : ICashPaymentService
    {    
        ICashDeviceAdapter _cashDevice;
        private IStorageService _storageService;

        public CashPaymentService(ICashDeviceAdapter cashDevice)
        {
            _cashDevice = cashDevice;

        }

        public CashPaymentService(ICashDeviceAdapter cashDevice,IStorageService storageService)
        {
            _cashDevice = cashDevice;

            _storageService = storageService;

            _cashDevice.OnChange += DeviceOnChange;

            _cashDevice.OnReceive += DeviceOnReceive;

            _cashDevice.OnTest += DeviceOnTest;

            _cashDevice.OnStop += DeviceOnStop;
        }

        private void DeviceOnStop(object sender, EventItem e)
        {
            if (e.IsError)
                _storageService.AddCashPaymentDetails(CashPaymentDetail.Create(0.0m, e.Level.ToString(), e.ErrorMessage));
            else
                _storageService.AddCashPaymentDetails(CashPaymentDetail.Create(0.0m, e.Level.ToString(), e.LayoutMessage));

            OnStop?.Invoke(sender, e);
        }

        private void DeviceOnTest(object sender, TestResultCash e)
        {
            _storageService.AddCashPaymentDetails(CashPaymentDetail.Create(0.0m, e.Result.ToString(), e.Description));

            OnTest?.Invoke(sender, e);
        }

        private void DeviceOnReceive(object sender, EventCashReceive e)
        {
            if (e.Event.IsError)
                _storageService.AddCashPaymentDetails(CashPaymentDetail.Create(e.Money.Value, e.Event.Level.ToString(), e.Event.ErrorMessage));
            else
                _storageService.AddCashPaymentDetails(CashPaymentDetail.Create(e.Money.Value, e.Event.Level.ToString(), e.Event.LayoutMessage));

            OnReceive?.Invoke(sender, e);
        }

        private void DeviceOnChange(object sender, EventCashReceive e)
        {
            if (e.Event.IsError)
                _storageService.AddCashPaymentDetails(CashPaymentDetail.Create(e.Money.Value, e.Event.Level.ToString(), e.Event.ErrorMessage));
            else
                _storageService.AddCashPaymentDetails(CashPaymentDetail.Create(e.Money.Value, e.Event.Level.ToString(), e.Event.LayoutMessage));

            OnChange?.Invoke(sender, e);
        }

        public CashPaymentService()
        {
        }

        public event EventHandler<EventCashReceive> OnChange;


        public event EventHandler<EventCashReceive> OnReceive;


        public event EventHandler<TestResultCash> OnTest;


        public event EventHandler<EventItem> OnStop;

        public void CashReceive(Money money)
        {
            _storageService.AddCashPaymentDetails(CashPaymentDetail.Create(money.Value, "Success", "Begin receive"));

            _cashDevice.CashReceive(money);
        }

        public void GiveChange(Money money)
        {
            _storageService.AddCashPaymentDetails(CashPaymentDetail.Create(money.Value, "Success", "Begin change"));

            _cashDevice.GiveChange(money);
        }

        public void StopDevice()
        {
            _storageService.AddCashPaymentDetails(CashPaymentDetail.Create(0.0m, "Success", "Begin stop"));

            _cashDevice.Stop();
        }

        public void Test()
        {
            _storageService.AddCashPaymentDetails(CashPaymentDetail.Create(0.0m, "Success", "Begin test"));

            _cashDevice.Test();
        }
    }
}
