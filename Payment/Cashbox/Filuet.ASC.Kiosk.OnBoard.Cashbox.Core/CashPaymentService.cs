using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using Filuet.Utils.Extensions;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Core
{
    public class CashPaymentService : ICashPaymentService
    {
        
        

        ICashDeviceAdapter _cashDevice;

        public CashPaymentService(ICashDeviceAdapter cashDevice)
        {
            _cashDevice = cashDevice;

        }

        public CashPaymentService()
        {
        }

        public event EventHandler<EventCashReceive> OnChange
        {
            add
            {
                _cashDevice.OnChange += value;
            }
            remove
            {
                _cashDevice.OnChange -= value;
            }
        }

        public event EventHandler<EventCashReceive> OnAcceptance
        {
            add
            {
                _cashDevice.OnAcceptance += value;
            }
            remove
            {
                _cashDevice.OnAcceptance -= value;
            }
        }

        public event EventHandler<TestResultCash> OnTest
        {
            add
            {
                _cashDevice.OnTest+=value;
            }

            remove
            {
                _cashDevice.OnTest-=value;
            }
        }

        public event EventHandler<EventItem> OnStop
        {
            add
            {
                _cashDevice.OnStop += value;
            }

            remove
            {
                _cashDevice.OnStop -= value;
            }
        }

        public void CashAcceptance()
        {
            throw new NotImplementedException();
        }

        public void CashAcceptance(Money money)
        {
            _cashDevice.CashAcceptance(money);

        }

        public void GiveChange(Money money)
        {
            _cashDevice.GiveChange(money);
        }

        public void StopDevice()
        {
            _cashDevice.Stop();
        }

        public void Test()
        {
            _cashDevice.Test();
        }
    }
}
