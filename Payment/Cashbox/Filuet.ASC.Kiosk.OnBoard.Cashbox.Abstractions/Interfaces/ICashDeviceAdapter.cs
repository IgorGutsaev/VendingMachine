using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces
{
    public interface ICashDeviceAdapter
    {
        event EventHandler<CashEventArgs> OnReceive;

        event EventHandler<TestResultCash> OnTest;

        event EventHandler<CashEventArgs> OnChange;

        event EventHandler<StopCashEventArgs> OnStop;

        void CashReceive(Money money);

        void GiveChange(Money money);

        void Test();
        void Stop();
    }
}
