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
        CashAccepted,
        BadCashAccepted,
        GiveChanged,
        BadGiveChanged
    }

    public class CashDeviceMock : ICashDeviceAdapter
    {
        private TestWork _type;

        public event EventHandler<EventCashReceive> OnAcceptance;
        public event EventHandler<TestResultCash> OnTest;
        public event EventHandler<EventCashReceive> OnChange;
        public event EventHandler<EventItem> OnStop;

        public CashDeviceMock(TestWork type)
        {
            _type = type;
        }

        public void CashAcceptance(Money money)
        {
            EventCashReceive eventCashReceive = new EventCashReceive();
            switch (_type)
            {
                case TestWork.CashAccepted:
                    eventCashReceive.Money = money;
                    eventCashReceive.Event = EventItem.Info("CashReceive");

                    break;
                case TestWork.BadCashAccepted:
                    eventCashReceive.Money = money;
                    eventCashReceive.Event = EventItem.Error("CashReceive");

                    break;
                case TestWork.BadGiveChanged:
                    break;
                default:
                    break;
            }

            OnAcceptance?.Invoke(this, eventCashReceive);


        }

        public void Test()
        {
            TestResultCash result = new TestResultCash();

            switch (_type)
            {
                case TestWork.CashAccepted:
                    result.Result = TestResultError.None;
                    result.Description = "None error";
                    break;
                case TestWork.BadCashAccepted:
                    result.Result = TestResultError.BillReceiverError;
                    result.Description = "Bill receiver error";
                    break;
                case TestWork.BadGiveChanged:
                    break;
                default:
                    break;
            }

            OnTest?.Invoke(this, result);
        }

        public void GiveChange(Money money)
        {
            EventCashReceive eventCash = new EventCashReceive();

            switch (_type)
            {
                case TestWork.CashAccepted:
                    
                    break;
                case TestWork.BadCashAccepted:
                    break;
                case TestWork.GiveChanged:
                    eventCash.Event = EventItem.Info("Give change");
                    eventCash.Money = money;
                    break;
                case TestWork.BadGiveChanged:
                    eventCash.Event = EventItem.Error("Give change error");
                    eventCash.Money = money;
                    break;
                default:
                    break;
            }

            OnChange?.Invoke(this, eventCash);
        }

        public void Stop()
        {
            EventItem eventItem = EventItem.Info("Device stoped");

            OnStop?.Invoke(this, eventItem);
        }
    }
}
