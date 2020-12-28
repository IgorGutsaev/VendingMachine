using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions
{
    public interface ICashPaymentService
    {
        IEnumerable<ICashDeviceAdapter> CashDevices { get; set; }

        void IssueChange(Money change);

        void Stop();

        event EventHandler<CashIncomeEventArgs> OnReceived;
        event EventHandler<StopCashDeviceEventArgs> OnStop;
    }
}
