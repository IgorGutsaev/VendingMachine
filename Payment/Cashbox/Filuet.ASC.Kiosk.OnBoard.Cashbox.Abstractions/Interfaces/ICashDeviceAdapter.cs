using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces
{
    public interface ICashDeviceAdapter
    {
        uint IssueIndex { get; }

        /// <summary>
        /// Upper threshold of money to collect. Give the change after the amount collected 
        /// It might to be reduced during an order session due to other money income sources (coin acceptor/card reader/external payments...)
        /// </summary>
        /// <param name="money">Expected amount</param>
        /// <remarks>We ought to know amount to be received lest collect more than expected</remarks>
        void ReduceOrSetDutyTo(Money money);

        Money GiveChange(Money change);

        void Test();

        void StopPayment();

        /// <summary>
        /// Start the device
        /// </summary>
        void Start();

        /// <summary>
        /// Stop the device
        /// </summary>
        void Stop();

        event EventHandler<CashIncomeEventArgs> OnMoneyReceived;

        event EventHandler<TestResultCash> OnTest;

        event EventHandler<CashIssueEventArgs> OnSomeChangeIssued;

        event EventHandler<StopCashDeviceEventArgs> OnStop;

        event EventHandler<StartCashDeviceEventArgs> OnStart;
    }
}
