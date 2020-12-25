using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces
{
    public interface ICashDeviceAdapter
    {
        event EventHandler<CashIncomeEventArgs> OnMoneyReceived;

        event EventHandler<TestResultCash> OnTest;

        event EventHandler<CashIncomeEventArgs> OnChangeIssued;

        event EventHandler<StopCashDeviceEventArgs> OnStop;

        event EventHandler<StartCashDeviceEventArgs> OnStart;


        /// <summary>
        /// Upper threshold of money to collect. Give the change after the amount collected 
        /// It might to be reduced during an order session due to other money income sources (coin acceptor/card reader/external payments...)
        /// </summary>
        /// <param name="money">Expected amount</param>
        /// <remarks>We ought to know amount to be received lest collect more than expected</remarks>
        void ReduceOrSetDutyTo(Money money);

        void GiveChange(Money money);

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
    }
}
