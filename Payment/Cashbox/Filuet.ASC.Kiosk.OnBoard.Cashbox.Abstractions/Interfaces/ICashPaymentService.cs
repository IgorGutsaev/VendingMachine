using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions
{
    public interface ICashPaymentService
    {
        void CashReceive(Money money);

        void GiveChange(Money money);

        void Stop();

        void AddCashDevice(ICashDeviceAdapter cashDevice);

        void RemoveCashDevice();

        event EventHandler<CashEventArgs> OnReceived;
        event EventHandler<CashEventArgs> OnGivedChange;
        event EventHandler<StopCashEventArgs> OnStop;
    }
}
