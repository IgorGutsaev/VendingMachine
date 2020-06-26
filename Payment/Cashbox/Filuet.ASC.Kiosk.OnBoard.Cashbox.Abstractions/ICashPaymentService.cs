using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions
{
    public interface ICashPaymentService
    {
        void Test();

        void CashAcceptance(Money money);

        event EventHandler<EventCashReceive> OnAcceptance;

        event EventHandler<EventCashReceive> OnChange;

        event EventHandler<TestResultCash> OnTest;

        event EventHandler<EventItem> OnStop;

        void GiveChange(Money money);

        void StopDevice();
    }
}
