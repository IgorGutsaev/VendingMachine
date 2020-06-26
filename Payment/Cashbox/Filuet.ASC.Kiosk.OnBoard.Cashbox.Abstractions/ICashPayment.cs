using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions
{
    public interface ICashPayment
    {
        decimal Amount { get; set; }
        bool Test();

        void CashAcceptance(Money money);

        //event EventHandler<EventItem> OnEvent;

        event EventHandler<EventItem> OnBadCashAcceptance;

        event EventHandler<EventItem> OnGoodCashAcceptance;

        event EventHandler<EventItem> OnBadCashOut;

        void CashOut(Money money);

        void StopDevice();
    }
}
