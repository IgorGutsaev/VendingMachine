using Filuet.ASC.Kiosk.OnBoard.Cashless.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Cashless.Abstractions
{
    public interface ICardDeviceAdapter
    {
        void Test();

        void StopDevice();

        void StopPayment();

        void StartPayment(Money money);

        void ReturnPayment(Money money);

        event EventHandler<TestCardEventArgs> OnTest;

        event EventHandler<StopCardEventArgs> OnStopDevice;

        event EventHandler<StopCardEventArgs> OnStopPayment;

        event EventHandler<CardEventArgs> OnStartPayment;

        event EventHandler<CardEventArgs> OnFinishedPayment;

        event EventHandler<CardEventArgs> OnReturnPayment;
    }
}
