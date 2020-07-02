using Filuet.ASC.Kiosk.OnBoard.Cashless.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashless.Abstractions
{
    public interface ICardPaymentService
    {
        void AddCardDevice(ICardDeviceAdapter cardDevice);

        void RemoveCardDevice();

        void StopPayment();

        void StartPayment(Money money);

        void StartReturnPayment(Money money);

        event EventHandler<StopCardEventArgs> OnStop;
        event EventHandler<CardEventArgs> OnPayment;
        event EventHandler<CardEventArgs> OnReturnPayment;
    }
}
