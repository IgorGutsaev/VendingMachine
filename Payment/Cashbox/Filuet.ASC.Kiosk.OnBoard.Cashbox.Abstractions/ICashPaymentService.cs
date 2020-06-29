using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions
{
    public interface ICashPaymentService
    {
        void Test();

        void CashReceive(Money money);

        event EventHandler<CashEventArgs> OnReceive;

        event EventHandler<CashEventArgs> OnChange;

        event EventHandler<TestResultCash> OnTest;

        event EventHandler<StopCashEventArgs> OnStop;

        void GiveChange(Money money);

        void StopDevice();

        void AddStorage(IStorageService storageService);

        void RemoveCashDevice();

        void AddCashDevice(ICashDeviceAdapter cashDevice);

        void RemoveStorage();
    }
}
