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

        void IssueChange(Money money);

        void Stop();



       // void RemoveCashDevice();

        event EventHandler<CashIncomeEventArgs> OnReceived;
        event EventHandler<CashIncomeEventArgs> OnGivedChange;
        event EventHandler<StopCashDeviceEventArgs> OnStop;
    }
}
