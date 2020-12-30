using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Core;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Tests
{
    public class CashPaymentTest
    {
        private ICashPaymentService _cashPaymentService = new CashPaymentService();


        private decimal _amount;

     //   public CashDeviceMock ICashDeviceAdapter { get; private set; }

        private TestWorkCash _type;

        public CashPaymentTest()
        {
            _cashPaymentService = new CashPaymentService();

            //_cashPaymentService.OnGivedChange += CashPaymentService_OnGivedChange;
            //_cashPaymentService.OnReceived += CashPaymentService_OnReceived;
            _cashPaymentService.OnStop += CashPaymentService_OnStop;

        }

        private void CashPaymentService_OnStop(object sender, StopCashDeviceEventArgs e)
        {
            if (_type == TestWorkCash.GoodStop)
            {
                Assert.False(e.Event.IsError);
            }
            else
            {
                Assert.True(e.Event.IsError);
            }
        }

        //private void CashPaymentService_OnReceived(object sender, CashIncomeEventArgs e)
        //{
        //    if (_type == TestWorkCash.GoodReceived)
        //    {
        //        Assert.False(e.Event.IsError);
        //    }
        //    else
        //    {
        //        Assert.True(e.Event.IsError);
        //    }
        //}

        //private void CashPaymentService_OnGivedChange(object sender, CashIncomeEventArgs e)
        //{
        //    if (_type == TestWorkCash.GoodGivedChange)
        //    {
        //        Assert.False(e.Event.IsError);
        //    }
        //    else
        //    {
        //        Assert.True(e.Event.IsError);
        //    }
        //}

        [Theory]
        [InlineData(10.0, CurrencyCode.RussianRouble)]
        [InlineData(99.0, CurrencyCode.Euro)]
        public void Test_CashReceive(decimal amount, CurrencyCode currency)
        {
            // Prepare
            Money income = null;
            Money money = Money.Create(amount, currency);

            var mock = new Mock<ICashDeviceAdapter>();
           // mock.Setup(a => a.CashReceive(money)).Callback(() => mock.Object.OnReceive );
            _cashPaymentService.CashDevices = new ICashDeviceAdapter[] { mock.Object };
            _cashPaymentService.OnReceived += (sender, e) => { 
                income = e.Money.Native;
            };

            // Perform
            mock.Object.ReduceOrSetDutyTo(money);

            // Post-validate
            Assert.Equal(money, income);
        }

        //[Theory]
        //[InlineData(99.9, CurrencyCode.RussianRouble, TestWorkCash.GoodGivedChange)]
        //[InlineData(98.9, CurrencyCode.RussianRouble, TestWorkCash.BadGivedChange)]
        //[InlineData(97, CurrencyCode.RussianRouble, TestWorkCash.BadReceived)]
        //[InlineData(95, CurrencyCode.RussianRouble, TestWorkCash.GoodReceived)]
        //[InlineData(95, CurrencyCode.RussianRouble, TestWorkCash.GoodStop)]
        //[InlineData(95, CurrencyCode.RussianRouble, TestWorkCash.BadStop)]
        //public void Test_GiveChange(decimal amount, CurrencyCode currencyCode, TestWorkCash type)
        //{
        //    //prepare
        //    _type = type;
        //    _cashPaymentService.AppendCashDevice(new CashDeviceMock(type));

        //    Money money = Money.Create(amount, currencyCode);

        //    _amount = amount;

        //    //perform
        //    _cashPaymentService.IssueChange(money);

        //    _cashPaymentService.RemoveCashDevice();
        //}

        //[Theory]
        //[InlineData(TestWorkCash.GoodGivedChange)]
        //[InlineData(TestWorkCash.BadGivedChange)]
        //[InlineData(TestWorkCash.BadReceived)]
        //[InlineData(TestWorkCash.GoodReceived)]
        //[InlineData(TestWorkCash.GoodStop)]
        //[InlineData(TestWorkCash.BadStop)]
        //public void Test_Stop(TestWorkCash type)
        //{
        //    //prepare
        //    _type = type;

        //    _cashPaymentService.AppendCashDevice(new CashDeviceMock(type));


        //    _cashPaymentService.Stop();

        //    _cashPaymentService.RemoveCashDevice();
        //}


    }
}
