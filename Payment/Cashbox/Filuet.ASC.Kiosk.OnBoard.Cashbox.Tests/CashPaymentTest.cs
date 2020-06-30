using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Core;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using Xunit;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Tests
{
    public class CashPaymentTest
    {
        private ICashPaymentService _cashPaymentService = new CashPaymentService();


        private decimal _amount;

        public CashDeviceMock ICashDeviceAdapter { get; private set; }

        private TestWorkCash _type;

        public CashPaymentTest()
        {
            _cashPaymentService = new CashPaymentService();

            _cashPaymentService.OnBadGivedChange += CashPaymentService_OnBadGivedChange;
            _cashPaymentService.OnBadReceived += CashPaymentService_OnBadReceived;
            _cashPaymentService.OnBadStop += CashPaymentService_OnBadStop;
            _cashPaymentService.OnGoodGivedChange += CashPaymentService_OnGoodGivedChange;
            _cashPaymentService.OnGoodReceived += CashPaymentService_OnGoodReceived;
            _cashPaymentService.OnGoodStop += CashPaymentService_OnGoodStop;
        }

        private void CashPaymentService_OnGoodStop(object sender, StopCashEventArgs e)
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

        private void CashPaymentService_OnGoodReceived(object sender, CashEventArgs e)
        {
            if (_type == TestWorkCash.GoodReceived)
            {
                Assert.False(e.Event.IsError);
            }
            else
            {
                Assert.True(e.Event.IsError);
            }
        }

        private void CashPaymentService_OnGoodGivedChange(object sender, CashEventArgs e)
        {
            if (_type == TestWorkCash.GoodGivedChange)
            {
                Assert.False(e.Event.IsError);
            }
            else
            {
                Assert.True(e.Event.IsError);
            }
        }

        private void CashPaymentService_OnBadStop(object sender, StopCashEventArgs e)
        {
            Assert.True(e.Event.IsError);
        }

        private void CashPaymentService_OnBadReceived(object sender, CashEventArgs e)
        {
            Assert.True(e.Event.IsError);
        }

        private void CashPaymentService_OnBadGivedChange(object sender, CashEventArgs e)
        {
            Assert.True(e.Event.IsError);
        }

        [Theory]
        [InlineData(100.0,CurrencyCode.RussianRouble,TestWorkCash.GoodReceived)]
        [InlineData(99.0,CurrencyCode.RussianRouble,TestWorkCash.BadReceived)]
        [InlineData(98.0,CurrencyCode.RussianRouble,TestWorkCash.GoodGivedChange)]
        [InlineData(97.0,CurrencyCode.RussianRouble,TestWorkCash.BadGivedChange)]
        [InlineData(95, CurrencyCode.RussianRouble, TestWorkCash.GoodStop)]
        [InlineData(95, CurrencyCode.RussianRouble, TestWorkCash.BadStop)]
        public void Test_CashReceive(decimal amount, CurrencyCode currency,TestWorkCash type)
        {
            //prepare
            _amount = amount;

            _type = type;

            _cashPaymentService.AddCashDevice(new CashDeviceMock(type));
           
            Money money = Money.Create(amount, currency);

            // Perform
            _cashPaymentService.CashReceive(money);

            _cashPaymentService.RemoveCashDevice();
        }

        [Theory]
        [InlineData(99.9,CurrencyCode.RussianRouble,TestWorkCash.GoodGivedChange)]
        [InlineData(98.9,CurrencyCode.RussianRouble,TestWorkCash.BadGivedChange)]
        [InlineData(97,CurrencyCode.RussianRouble,TestWorkCash.BadReceived)]
        [InlineData(95,CurrencyCode.RussianRouble,TestWorkCash.GoodReceived)]
        [InlineData(95,CurrencyCode.RussianRouble,TestWorkCash.GoodStop)]
        [InlineData(95,CurrencyCode.RussianRouble,TestWorkCash.BadStop)]
        public void Test_GiveChange(decimal amount,CurrencyCode currencyCode,TestWorkCash type)
        {
            //prepare
            _type = type;
            _cashPaymentService.AddCashDevice(new CashDeviceMock(type));

            Money money = Money.Create(amount, currencyCode);

            _amount = amount;

            //perform
            _cashPaymentService.GiveChange(money);

            _cashPaymentService.RemoveCashDevice();
        }

        [Theory]
        [InlineData( TestWorkCash.GoodGivedChange)]
        [InlineData( TestWorkCash.BadGivedChange)]
        [InlineData( TestWorkCash.BadReceived)]
        [InlineData( TestWorkCash.GoodReceived)]
        [InlineData( TestWorkCash.GoodStop)]
        [InlineData( TestWorkCash.BadStop)]
        public void Test_Stop(TestWorkCash type)
        {
            //prepare
            _type = type;

            _cashPaymentService.AddCashDevice(new CashDeviceMock(type));

            _cashPaymentService.Stop();

            _cashPaymentService.RemoveCashDevice();
        }


    }
}
