using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces
{
    public interface ICashDeviceAdapter
    {
        event EventHandler<EventCashReceive> OnAcceptance;

        event EventHandler<TestResultCash> OnTest;

        event EventHandler<EventCashReceive> OnChange;

        event EventHandler<EventItem> OnStop;

        void CashAcceptance(Money money);

        void GiveChange(Money money);

        void Test();
        void Stop();
    }
}
