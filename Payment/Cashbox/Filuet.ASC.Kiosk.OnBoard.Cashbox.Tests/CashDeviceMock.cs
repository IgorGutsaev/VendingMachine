using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Tests
{
    public enum TestWorkCash
    {
        GoodReceived,
        BadReceived,
        GoodGivedChange,
        BadGivedChange,
        GoodStop,
        BadStop
    }

    public class CashDeviceMock : ICashDeviceAdapter
    {
        private TestWorkCash _type;


        public CashDeviceMock(TestWorkCash type)
        {
            _type = type;
        }

        public event EventHandler<CashEventArgs> OnReceive;
        public event EventHandler<TestResultCash> OnTest;
        public event EventHandler<CashEventArgs> OnChange;
        public event EventHandler<StopCashEventArgs> OnStopPayment;
        public event EventHandler<StopCashEventArgs> OnStopDevice;

        public void CashReceive(Money money)
        {
            switch (_type)
            {
                case TestWorkCash.GoodReceived:
                    OnReceive?.Invoke(this, new CashEventArgs() {Money = money,Event = EventItem.Info("Cash received good") });
                    break;
                case TestWorkCash.BadReceived:
                    OnReceive?.Invoke(this, new CashEventArgs() { Money = money, Event = EventItem.Error("Cash received bad") });

                    break;
                case TestWorkCash.GoodGivedChange:
                    OnChange?.Invoke(this, new CashEventArgs() { Money = money, Event = EventItem.Error("Cash gived change good") });

                    break;
                case TestWorkCash.BadGivedChange:
                    OnChange?.Invoke(this, new CashEventArgs() { Money = money, Event = EventItem.Error("Cash gived change bad") });

                    break;
                case TestWorkCash.GoodStop:
                    OnStopPayment?.Invoke(this, new StopCashEventArgs() {  Event = EventItem.Error("Cash received stoped good") });

                    break;
                case TestWorkCash.BadStop:
                    OnStopPayment?.Invoke(this, new StopCashEventArgs() {  Event = EventItem.Error("Cash received stoped bed") });

                    break;
                default:
                    OnReceive?.Invoke(this, new CashEventArgs() { Money = money, Event = EventItem.Error("Cash accept has error") });

                    break;
            }

        }

        public void GiveChange(Money money)
        {
            switch (_type)
            {
                case TestWorkCash.GoodReceived:
                    OnReceive?.Invoke(this, new CashEventArgs() { Money = money, Event = EventItem.Error("Cash received good") });
                    break;
                case TestWorkCash.BadReceived:
                    OnReceive?.Invoke(this, new CashEventArgs() { Money = money, Event = EventItem.Error("Cash received bad") });

                    break;
                case TestWorkCash.GoodGivedChange:
                    OnChange?.Invoke(this, new CashEventArgs() { Money = money, Event = EventItem.Info("Cash gived change good") });

                    break;
                case TestWorkCash.BadGivedChange:
                    OnChange?.Invoke(this, new CashEventArgs() { Money = money, Event = EventItem.Error("Cash gived change bad") });

                    break;
                case TestWorkCash.GoodStop:
                    OnStopPayment?.Invoke(this, new StopCashEventArgs() {  Event = EventItem.Error("Cash received stoped good") });

                    break;
                case TestWorkCash.BadStop:
                    OnStopPayment?.Invoke(this, new StopCashEventArgs() {  Event = EventItem.Error("Cash received stoped bed") });

                    break;
                default:
                    OnChange?.Invoke(this, new CashEventArgs() { Money = money, Event = EventItem.Error("Cash accept has error") });

                    break;
            }
        }

        public void StopDevice()
        {
            throw new NotImplementedException();
        }

        public void StopPayment()
        {
            switch (_type)
            {
                case TestWorkCash.GoodReceived:
                    OnReceive?.Invoke(this, new CashEventArgs() {  Event = EventItem.Error("Cash received good") });
                    break;
                case TestWorkCash.BadReceived:
                    OnReceive?.Invoke(this, new CashEventArgs() {  Event = EventItem.Error("Cash received bad") });

                    break;
                case TestWorkCash.GoodGivedChange:
                    OnChange?.Invoke(this, new CashEventArgs() {  Event = EventItem.Error("Cash gived change good") });

                    break;
                case TestWorkCash.BadGivedChange:
                    OnChange?.Invoke(this, new CashEventArgs() {  Event = EventItem.Error("Cash gived change bad") });

                    break;
                case TestWorkCash.GoodStop:
                    OnStopPayment?.Invoke(this, new StopCashEventArgs() {  Event = EventItem.Info("Cash received stoped good") });

                    break;
                case TestWorkCash.BadStop:
                    OnStopPayment?.Invoke(this, new StopCashEventArgs() {  Event = EventItem.Error("Cash received stoped bed") });

                    break;
                default:
                    OnStopPayment?.Invoke(this, new StopCashEventArgs() {  Event = EventItem.Error("Cash accept has error") });

                    break;
            }
        }

        public void Test()
        {
            throw new NotImplementedException();
        }
    }
}
