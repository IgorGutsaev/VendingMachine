using Filuet.ASC.Kiosk.OnBoard.Cashless.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.Utils.Common.Business;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Cashless.Abstractions
{
    public interface ICardPaymentService
    {
        void AddCardDevice(ICardDeviceAdapter cardDevice);

        void RemoveCardDevice();

        void StopPayment();

        void StartPayment(Money money);

        void ReturnPayment(Money money);

        event EventHandler<StopCardEventArgs> OnGoodStop;
        event EventHandler<StopCardEventArgs> OnBadStop;

        event EventHandler<CardEventArgs> OnGoodPayment;
        event EventHandler<CardEventArgs> OnBadPayment;

        event EventHandler<CardEventArgs> OnGoodReturnPayment;
        event EventHandler<CardEventArgs> OnBadReturnPayment;
    }
}
