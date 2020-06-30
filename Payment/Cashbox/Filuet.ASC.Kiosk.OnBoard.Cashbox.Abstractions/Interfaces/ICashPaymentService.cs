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
        event EventHandler<CashEventArgs> OnGoodReceived;
        event EventHandler<CashEventArgs> OnBadReceived;

        event EventHandler<CashEventArgs> OnGoodGivedChange;
        event EventHandler<CashEventArgs> OnBadGivedChange;

        event EventHandler<StopCashEventArgs> OnGoodStop;
        event EventHandler<StopCashEventArgs> OnBadStop;

        void CashReceive(Money money);

        void GiveChange(Money money);

        void Stop();

        void AddCashDevice(ICashDeviceAdapter cashDevice);

        void RemoveCashDevice();

    }
}
