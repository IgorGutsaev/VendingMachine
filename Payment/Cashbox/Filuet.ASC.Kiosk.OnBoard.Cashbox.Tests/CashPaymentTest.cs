using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using Xunit;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Tests
{
    public class CashPaymentTest:BaseTest
    {

        private decimal _amount;

        public CashDeviceMock ICashDeviceAdapter { get; private set; }

        [Theory]
        [InlineData(100.0,CurrencyCode.RussianRouble,TestWork.CashReceived)]
        [InlineData(99.0,CurrencyCode.RussianRouble,TestWork.BadCashReceived)]
        [InlineData(98.0,CurrencyCode.RussianRouble,TestWork.GiveChanged)]
        [InlineData(97.0,CurrencyCode.RussianRouble,TestWork.BadGiveChanged)]
        public void Test_CashReceive(decimal amount, CurrencyCode currency,TestWork type)
        {
            //prepare
            _amount = amount;

            cashPaymentService.AddCashDevice(new CashDeviceMock(type));

            switch (type)
            {
                case TestWork.CashReceived:
                    cashPaymentService.OnReceive += Service_OnReceived_Good;

                    break;
                case TestWork.BadCashReceived:

                    cashPaymentService.OnReceive += Service_OnReceived_Bad;
                    break;
                default:
                    cashPaymentService.OnReceive += Service_OnReceived_Another;
                    break;
            }

            
            Money money = Money.Create(amount, currency);

            // Perform
            cashPaymentService.CashReceive(money);

            cashPaymentService.RemoveCashDevice();
        }

        private void Service_OnReceived_Another(object sender, CashEventArgs e)
        {
            Assert.NotNull(e.Event);

            Assert.NotNull(e.Money);

            Assert.Equal(_amount, e.Money.Value);

            Assert.Equal(e.Event.Level.ToString(), EventItem.EventLevel.Debug.ToString());
        }


        [Fact]
        public void Test_CashTest()
        {
            //prepare
            cashPaymentService.AddCashDevice(new CashDeviceMock(TestWork.CashReceived));

            cashPaymentService.OnTest += Service_OnTest;

            //perform
            cashPaymentService.Test();

            cashPaymentService.RemoveCashDevice();
        }

        [Fact]
        public void Test_DeviceStop()
        {
            //prepare
            cashPaymentService.AddCashDevice(new CashDeviceMock(TestWork.CashReceived));


            cashPaymentService.OnStop += Service_OnStop;

            //perform
            cashPaymentService.StopDevice();

            cashPaymentService.RemoveCashDevice();
        }

        [Theory]
        [InlineData(99.9,CurrencyCode.RussianRouble,TestWork.GiveChanged)]
        [InlineData(98.9,CurrencyCode.RussianRouble,TestWork.BadGiveChanged)]
        [InlineData(97,CurrencyCode.RussianRouble,TestWork.BadCashReceived)]
        [InlineData(95,CurrencyCode.RussianRouble,TestWork.CashReceived)]
        public void Test_GiveChange(decimal amount,CurrencyCode currencyCode,TestWork type)
        {
            //prepare
            cashPaymentService.AddCashDevice(new CashDeviceMock(type));

            Money money = Money.Create(amount, currencyCode);

            _amount = amount;

            switch (type)
            {
                case TestWork.GiveChanged:
                    cashPaymentService.OnChange += Service_OnChange_Good;

                    break;
                case TestWork.BadGiveChanged:
                    cashPaymentService.OnChange += Service_OnChange_Bad;

                    break;
                default:
                    cashPaymentService.OnChange += Service_OnChange_Another;
                    break;
            }


            //perform
            cashPaymentService.GiveChange(money);

            cashPaymentService.RemoveCashDevice();
        }

        private void Service_OnChange_Another(object sender, CashEventArgs e)
        {
            Assert.NotNull(e.Event);

            Assert.NotNull(e.Money);

            Assert.Equal(_amount, e.Money.Value);

            Assert.Equal(e.Event.Level.ToString(), EventItem.EventLevel.Debug.ToString());
        }

        private void Service_OnChange_Bad(object sender, CashEventArgs e)
        {
            Assert.Equal(EventItem.EventLevel.Error.ToString(), e.Event.Level.ToString());
            Assert.Equal(_amount, e.Money.Value);
        }

        private void Service_OnChange_Good(object sender, CashEventArgs e)
        {
            Assert.Equal(EventItem.EventLevel.Info.ToString(), e.Event.Level.ToString());
            Assert.Equal(_amount, e.Money.Value);
        }

        private void Service_OnStop(object sender, CashEventArgs e)
        {
            Assert.Equal(e.Event.Level.ToString(), EventItem.EventLevel.Info.ToString());
        }

        private void Service_OnTest(object sender, Abstractions.TestResultCash e)
        {
            Assert.Equal(TestResultError.None.ToString(), e.Result.ToString());
        }

        private void Service_OnReceived_Bad(object sender, CashEventArgs e)
        {
            Assert.NotNull(e.Event);
            Assert.Equal(e.Event.Level.ToString(), EventItem.EventLevel.Error.ToString());

            Assert.NotNull(e.Money);
            Assert.Equal(_amount, e.Money.Value);
        }

        private void Service_OnReceived_Good(object sender, CashEventArgs e)
        {
            Assert.Equal(e.Event.Level.ToString(), EventItem.EventLevel.Info.ToString());

            Assert.Equal(_amount, e.Money.Value);
        }
    }
}
