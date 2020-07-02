using Filuet.ASC.Kiosk.OnBoard.Cashless.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashless.Abstractions
{
    public interface ICardDeviceAdapter
    {
        void Test();

        void StopDevice();

        void StopPayment();

        void StartPayment(Money money);

        void StartReturnPayment(Money money);

        event EventHandler<TestCardEventArgs> OnTest;

        event EventHandler<StopCardEventArgs> OnStopDevice;

        event EventHandler<StopCardEventArgs> OnStopPayment;

        event EventHandler<CardEventArgs> OnPayment;

        event EventHandler<CardEventArgs> OnReturnPayment;
    }
}
