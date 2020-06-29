using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Tests
{
    public enum TestWork
    {
        CashReceived,
        BadCashReceived,
        GiveChanged,
        BadGiveChanged
    }

    public class CashDeviceMock : ICashDeviceAdapter
    {
        private TestWork _type;

        public event EventHandler<CashEventArgs> OnReceive;
        public event EventHandler<TestResultCash> OnTest;
        public event EventHandler<CashEventArgs> OnChange;
        public event EventHandler<StopCashEventArgs> OnStop;

        public CashDeviceMock(TestWork type)
        {
            _type = type;
        }

        public void CashReceive(Money money)
        {
            CashEventArgs eventCashReceive = new CashEventArgs();
            switch (_type)
            {
                case TestWork.CashReceived:
                    eventCashReceive.Money = money;
                    eventCashReceive.Event = EventItem.Info("CashReceived");
                    
                    break;
                case TestWork.BadCashReceived:
                    eventCashReceive.Money = money;
                    eventCashReceive.Event = EventItem.Error("CashReceived");

                    break;
                default:
                    eventCashReceive.Money = money;
                    eventCashReceive.Event = EventItem.Debug("CashReceived");
                    break;
            }

            OnReceive?.Invoke(this, eventCashReceive);


        }

        public void Test()
        {
            TestResultCash result = new TestResultCash();

            switch (_type)
            {
                case TestWork.CashReceived:
                    result.Result = TestResultError.None;
                    result.Description = "None error";
                    break;
                case TestWork.BadCashReceived:
                    result.Result = TestResultError.BillReceiverError;
                    result.Description = "Bill receiver error";
                    break;
                default:
                    result.Result = TestResultError.None;

                    result.Description = "Cash Tested";
                    break;
            }

            OnTest?.Invoke(this, result);
        }

        public void GiveChange(Money money)
        {
            CashEventArgs eventCash = new CashEventArgs();

            switch (_type)
            {
                case TestWork.GiveChanged:
                    eventCash.Event = EventItem.Info("Give change");
                    eventCash.Money = money;
                    break;
                case TestWork.BadGiveChanged:
                    eventCash.Event = EventItem.Error("Give change error");
                    eventCash.Money = money;
                    break;
                default:
                    eventCash.Money = money;
                    eventCash.Event = EventItem.Debug("Gived change");
                    break;
            }

            OnChange?.Invoke(this, eventCash);
        }

        public void Stop()
        {
            EventItem eventItem = EventItem.Info("Device stoped");

            StopCashEventArgs cashEventArgs = new StopCashEventArgs()
            {
                Event = EventItem.Info("Device stoped"),
                Description = "Stop"
            };

            OnStop?.Invoke(this, cashEventArgs);
        }
    }
}
