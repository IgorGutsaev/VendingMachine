using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Tests
{
    public enum TestWork
    {
        CashAccepting,
        BadCashAccepted,
        BadCashOut
    }

    public class CashDeviceMock : ICashDeviceAdapter
    {
        private TestWork _type;

        public event EventHandler<EventCashReceive> OnCashReceive;
        public event EventHandler<TestResultCash> OnTest;

        public CashDeviceMock(TestWork type)
        {
            _type = type;
        }

        public void CashAcceptance(Money money)
        {
            EventCashReceive eventCashReceive = new EventCashReceive()
            {
                Money = money,
                Event = EventItem.Info("CashReceive")
            };
            switch (_type)
            {
                case TestWork.CashAccepting:
                    OnCashReceive?.Invoke(this, eventCashReceive);
                    break;
                case TestWork.BadCashAccepted:

                    break;
                case TestWork.BadCashOut:
                    break;
                default:
                    break;
            }

        }

        public void Test()
        {
            TestResultCash result = new TestResultCash()
            {
                Result = TestResultError.None,
                Description = $"None Error"
            };

            OnTest?.Invoke(this, result);
        }
    }
}
