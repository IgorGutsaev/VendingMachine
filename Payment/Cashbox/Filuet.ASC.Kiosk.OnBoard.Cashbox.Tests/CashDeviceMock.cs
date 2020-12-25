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

    //public class CashDeviceMock : ICashDeviceAdapter
    //{
    //    private TestWorkCash _type;


    //    public CashDeviceMock(TestWorkCash type)
    //    {
    //        _type = type;
    //    }

    //    public event EventHandler<CashIncomeEventArgs> OnMoneyReceived;
    //    public event EventHandler<TestResultCash> OnTest;
    //    public event EventHandler<CashIncomeEventArgs> OnChangeIssued;
    //    public event EventHandler<StopCashDeviceEventArgs> OnStopPayment;
    //    public event EventHandler<StopCashDeviceEventArgs> OnStop;
    //    public event EventHandler<StartCashDeviceEventArgs> OnStart;

    //    public void ReduceDutyTo(Money money)
    //    {
    //        switch (_type)
    //        {
    //            case TestWorkCash.GoodReceived:
    //                OnMoneyReceived?.Invoke(this, new CashIncomeEventArgs() {Money = money,Event = EventItem.Info("Cash received good") });
    //                break;
    //            case TestWorkCash.BadReceived:
    //                OnMoneyReceived?.Invoke(this, new CashIncomeEventArgs() { Money = money, Event = EventItem.Error("Cash received bad") });

    //                break;
    //            case TestWorkCash.GoodGivedChange:
    //                OnMoneyReceived?.Invoke(this, new CashIncomeEventArgs() { Money = money, Event = EventItem.Error("Cash gived change good") });

    //                break;
    //            case TestWorkCash.BadGivedChange:
    //                OnMoneyReceived?.Invoke(this, new CashIncomeEventArgs() { Money = money, Event = EventItem.Error("Cash gived change bad") });

    //                break;
    //            case TestWorkCash.GoodStop:
    //                OnMoneyReceived?.Invoke(this, new CashIncomeEventArgs() {  Event = EventItem.Error("Cash received stoped good") });

    //                break;
    //            case TestWorkCash.BadStop:
    //                OnMoneyReceived?.Invoke(this, new CashIncomeEventArgs() {  Event = EventItem.Error("Cash received stoped bed") });

    //                break;
    //            default:
    //                OnMoneyReceived?.Invoke(this, new CashIncomeEventArgs() { Money = money, Event = EventItem.Error("Cash accept has error") });

    //                break;
    //        }

    //    }

    //    public void GiveChange(Money money)
    //    {
    //        switch (_type)
    //        {
    //            case TestWorkCash.GoodReceived:
    //                OnChangeIssued?.Invoke(this, new CashIncomeEventArgs() { Money = money, Event = EventItem.Error("Cash received good") });
    //                break;
    //            case TestWorkCash.BadReceived:
    //                OnChangeIssued?.Invoke(this, new CashIncomeEventArgs() { Money = money, Event = EventItem.Error("Cash received bad") });

    //                break;
    //            case TestWorkCash.GoodGivedChange:
    //                OnChangeIssued?.Invoke(this, new CashIncomeEventArgs() { Money = money, Event = EventItem.Info("Cash gived change good") });

    //                break;
    //            case TestWorkCash.BadGivedChange:
    //                OnChangeIssued?.Invoke(this, new CashIncomeEventArgs() { Money = money, Event = EventItem.Error("Cash gived change bad") });

    //                break;
    //            case TestWorkCash.GoodStop:
    //                OnChangeIssued?.Invoke(this, new CashIncomeEventArgs() {  Event = EventItem.Error("Cash received stoped good") });

    //                break;
    //            case TestWorkCash.BadStop:
    //                OnChangeIssued?.Invoke(this, new CashIncomeEventArgs() {  Event = EventItem.Error("Cash received stoped bed") });

    //                break;
    //            default:
    //                OnChangeIssued?.Invoke(this, new CashIncomeEventArgs() { Money = money, Event = EventItem.Error("Cash accept has error") });

    //                break;
    //        }
    //    }

    //    public void Start()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Stop()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void StopPayment()
    //    {
    //        switch (_type)
    //        {
    //            case TestWorkCash.GoodReceived:
    //                OnStopPayment?.Invoke(this, new StopCashDeviceEventArgs() {  Event = EventItem.Error("Cash received good") });
    //                break;
    //            case TestWorkCash.BadReceived:
    //                OnStopPayment?.Invoke(this, new StopCashDeviceEventArgs() {  Event = EventItem.Error("Cash received bad") });

    //                break;
    //            case TestWorkCash.GoodGivedChange:
    //                OnStopPayment?.Invoke(this, new StopCashDeviceEventArgs() {  Event = EventItem.Error("Cash gived change good") });

    //                break;
    //            case TestWorkCash.BadGivedChange:
    //                OnStopPayment?.Invoke(this, new StopCashDeviceEventArgs() {  Event = EventItem.Error("Cash gived change bad") });

    //                break;
    //            case TestWorkCash.GoodStop:
    //                OnStopPayment?.Invoke(this, new StopCashDeviceEventArgs() {  Event = EventItem.Info("Cash received stoped good") });

    //                break;
    //            case TestWorkCash.BadStop:
    //                OnStopPayment?.Invoke(this, new StopCashDeviceEventArgs() {  Event = EventItem.Error("Cash received stoped bed") });

    //                break;
    //            default:
    //                OnStopPayment?.Invoke(this, new StopCashDeviceEventArgs() {  Event = EventItem.Error("Cash accept has error") });

    //                break;
    //        }
    //    }

    //    public void Test()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
