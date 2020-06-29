using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Core
{
    public class CashPaymentService : ICashPaymentService
    {    
        ICashDeviceAdapter _cashDevice;

        private IStorageService _storageService;

        public ICashDeviceAdapter CashDevice 
        { 
            get
            {
                if (_cashDevice == null)
                {
                    throw new ArgumentException("CashPaymnetService has not CashDevice", "CashDevice");
                }

                return _cashDevice;
            }
            private set 
            {
                _cashDevice = value;
            } 
        }        

        public IStorageService StorageService
        {
            get 
            {
                if (_storageService == null)
                {
                    throw new ArgumentException("CashPaymentService has not StorageService", "StorageService");
                }
                return _storageService; 
            }
            set 
            { _storageService = value; }
        }


        public CashPaymentService()
        {
            CashDevice.OnChange += DeviceOnChange;

            CashDevice.OnReceive += DeviceOnReceive;

            CashDevice.OnTest += DeviceOnTest;

            CashDevice.OnStop += DeviceOnStop;
        }

        public CashPaymentService(ICashDeviceAdapter cashDevice,IStorageService storageService):
            this()
        {
            CashDevice = cashDevice;

            StorageService = storageService;
        }

        private void DeviceOnStop(object sender, StopCashEventArgs e)
        {
            StorageService.AddCashPaymentDetails(CashPaymentDetail.Create(0.0m, e.Description, e.Event.LayoutMessage));
            
            OnStop?.Invoke(sender, e);
        }

        private void DeviceOnTest(object sender, TestResultCash e)
        {
            StorageService.AddCashPaymentDetails(CashPaymentDetail.Create(0.0m, e.Result.ToString(), e.Description));

            OnTest?.Invoke(sender, e);
        }

        private void DeviceOnReceive(object sender, CashEventArgs e)
        {
            if (e.Event.IsError)
                StorageService.AddCashPaymentDetails(CashPaymentDetail.Create(e.Money.Value, e.Event.Level.ToString(), e.Event.ErrorMessage));
            else
                StorageService.AddCashPaymentDetails(CashPaymentDetail.Create(e.Money.Value, e.Event.Level.ToString(), e.Event.LayoutMessage));

            OnReceive?.Invoke(sender, e);
        }

        private void DeviceOnChange(object sender, CashEventArgs e)
        {
            if (e.Event.IsError)
                StorageService.AddCashPaymentDetails(CashPaymentDetail.Create(e.Money.Value, e.Event.Level.ToString(), e.Event.ErrorMessage));
            else
                StorageService.AddCashPaymentDetails(CashPaymentDetail.Create(e.Money.Value, e.Event.Level.ToString(), e.Event.LayoutMessage));

            OnChange?.Invoke(sender, e);
        }

        public event EventHandler<CashEventArgs> OnChange;


        public event EventHandler<CashEventArgs> OnReceive;


        public event EventHandler<TestResultCash> OnTest;


        public event EventHandler<StopCashEventArgs> OnStop;

        public void CashReceive(Money money)
        {
            StorageService.AddCashPaymentDetails(CashPaymentDetail.Create(money.Value, "Success", "Begin receive"));

            CashDevice.CashReceive(money);
        }

        public void GiveChange(Money money)
        {
            StorageService.AddCashPaymentDetails(CashPaymentDetail.Create(money.Value, "Success", "Begin change"));

            CashDevice.GiveChange(money);
        }

        public void StopDevice()
        {
            StorageService.AddCashPaymentDetails(CashPaymentDetail.Create(0.0m, "Success", "Begin stop"));

            CashDevice.Stop();
        }

        public void Test()
        {
            StorageService.AddCashPaymentDetails(CashPaymentDetail.Create(0.0m, "Success", "Begin test"));

            CashDevice.Test();
        }

        public void AddCashDevice(ICashDeviceAdapter cashDevice)
        {
            if (cashDevice == null)
                throw new ArgumentException("CashDevice is null", "CashDevice");

            CashDevice = cashDevice;
        }

        public void RemoveCashDevice()
        {
            CashDevice = null;
        }

        public void AddStorage(IStorageService storageService)
        {
            if (storageService == null)
                throw new ArgumentException("StorageService is null", "StorageService");
            StorageService = storageService;
        }

        public void RemoveStorage()
        {
            StorageService = null;
        }
    }
}
