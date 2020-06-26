using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces
{
    public interface ICashDeviceAdapter
    {
        event EventHandler<EventCashReceive> OnCashReceive;

        event EventHandler<TestResultCash> OnTest;

        void CashAcceptance(Money money);

        void Test();
    }
}
