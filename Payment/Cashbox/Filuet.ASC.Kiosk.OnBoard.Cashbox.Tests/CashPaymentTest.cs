using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Core;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using Xunit;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Tests
{
    public class CashPaymentTest:BaseTest
    {

        private decimal _amount;

        [Theory]
        [InlineData(100.0,CurrencyCode.RussianRouble,TestWork.CashReceived)]
        [InlineData(99.0,CurrencyCode.RussianRouble,TestWork.BadCashReceived)]
        [InlineData(98.0,CurrencyCode.RussianRouble,TestWork.GiveChanged)]
        [InlineData(97.0,CurrencyCode.RussianRouble,TestWork.BadGiveChanged)]
        public void Test_CashReceive(decimal amount, CurrencyCode currency,TestWork type)
        {
            //prepare
            _amount = amount;

            CashPaymentService service = new CashPaymentService(new CashDeviceMock(type), StorageService);

            switch (type)
            {
                case TestWork.CashReceived:
                    service.OnReceive += Service_OnReceived_Good;

                    break;
                case TestWork.BadCashReceived:

                    service.OnReceive += Service_OnReceived_Bad;
                    break;
                default:
                    service.OnReceive += Service_OnReceived_Another;
                    break;
            }

            
            Money money = Money.Create(amount, currency);

            // Perform
            service.CashReceive(money);

            // Pre-validation
            //Assert.Equal(amount, _payment.Amount, 6);

            

            // Post-validation

            
        }

        private void Service_OnReceived_Another(object sender, EventCashReceive e)
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
            CashPaymentService service = new CashPaymentService(new CashDeviceMock(TestWork.CashReceived), StorageService);

            service.OnTest += Service_OnTest;

            //perform
            service.Test();
        }

        [Fact]
        public void Test_DeviceStop()
        {
            //prepare
            CashPaymentService service = new CashPaymentService(new CashDeviceMock(TestWork.CashReceived), StorageService);

            service.OnStop += Service_OnStop;

            //perform
            service.StopDevice();
        }

        [Theory]
        [InlineData(99.9,CurrencyCode.RussianRouble,TestWork.GiveChanged)]
        [InlineData(98.9,CurrencyCode.RussianRouble,TestWork.BadGiveChanged)]
        [InlineData(97,CurrencyCode.RussianRouble,TestWork.BadCashReceived)]
        [InlineData(95,CurrencyCode.RussianRouble,TestWork.CashReceived)]
        public void Test_GiveChange(decimal amount,CurrencyCode currencyCode,TestWork type)
        {
            //prepare
            CashPaymentService service = new CashPaymentService(new CashDeviceMock(type), StorageService);

            Money money = Money.Create(amount, currencyCode);

            _amount = amount;

            switch (type)
            {
                case TestWork.GiveChanged:
                    service.OnChange += Service_OnChange_Good;

                    break;
                case TestWork.BadGiveChanged:
                    service.OnChange += Service_OnChange_Bad;

                    break;
                default:
                    service.OnChange += Service_OnChange_Another;
                    break;
            }


            //perform
            service.GiveChange(money);
        }

        private void Service_OnChange_Another(object sender, EventCashReceive e)
        {
            Assert.NotNull(e.Event);

            Assert.NotNull(e.Money);

            Assert.Equal(_amount, e.Money.Value);

            Assert.Equal(e.Event.Level.ToString(), EventItem.EventLevel.Debug.ToString());
        }

        private void Service_OnChange_Bad(object sender, EventCashReceive e)
        {
            Assert.Equal(EventItem.EventLevel.Error.ToString(), e.Event.Level.ToString());
            Assert.Equal(_amount, e.Money.Value);
        }

        private void Service_OnChange_Good(object sender, EventCashReceive e)
        {
            Assert.Equal(EventItem.EventLevel.Info.ToString(), e.Event.Level.ToString());
            Assert.Equal(_amount, e.Money.Value);
        }

        private void Service_OnStop(object sender, EventItem e)
        {
            Assert.Equal(e.Level.ToString(), EventItem.EventLevel.Info.ToString());
        }

        private void Service_OnTest(object sender, Abstracti
            ons.TestResultCash e)
        {
            Assert.Equal(TestResultError.None.ToString(), e.Result.ToString());
        }

        private void Service_OnReceived_Bad(object sender, EventCashReceive e)
        {
            Assert.NotNull(e.Event);
            Assert.Equal(e.Event.Level.ToString(), EventItem.EventLevel.Error.ToString());

            Assert.NotNull(e.Money);
            Assert.Equal(_amount, e.Money.Value);
        }

        private void Service_OnReceived_Good(object sender, EventCashReceive e)
        {
            Assert.Equal(e.Event.Level.ToString(), EventItem.EventLevel.Info.ToString());

            Assert.Equal(_amount, e.Money.Value);
        }
    }
}
