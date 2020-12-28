using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Core
{
    public class CashPaymentService : ICashPaymentService
    {
        public CashPaymentService() { }

        public void IssueChange(Money change)
        {
            if (change <= 0)
                throw new ArgumentException("The change isn't specified");

            IList<ICashDeviceAdapter> devices = CashDevices.OrderBy(x => x.IssueIndex).ToList(); // Sort devices in priority order

            Money changeDebt = Money.From(change);
            var @lock = new ReaderWriterLockSlim();

            foreach (var device in devices)
            {
                @lock.EnterWriteLock();
                try
                {
                    while (changeDebt > 0)
                    {
                        Money nextChange = device.GiveChange(changeDebt);
                        if (nextChange == null)
                            break;
                        else changeDebt = changeDebt - nextChange; // Decrease change debt
                    }
                }
                finally
                {
                    @lock.ExitWriteLock();
                }
            }
        }

        public void Stop()
        {
            //CashDevice.StopPayment();
        }


        public IEnumerable<ICashDeviceAdapter> CashDevices { get; set; }

        public event EventHandler<CashIncomeEventArgs> OnReceived;
        public event EventHandler<CashIncomeEventArgs> OnGivedChange;
        public event EventHandler<StopCashDeviceEventArgs> OnStop;
    }
}
