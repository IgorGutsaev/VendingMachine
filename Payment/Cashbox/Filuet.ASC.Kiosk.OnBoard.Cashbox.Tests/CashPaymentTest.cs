using System;
using System.Diagnostics.Tracing;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Core;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using Xunit;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Tests
{
    public class CashPaymentTest
    {

        private decimal _amount;
        public CashPaymentTest()
        {  
        }

        [Theory]
        [InlineData(100.0,CurrencyCode.RussianRouble)]
        public void Test_CashAcceptance_Good(decimal amount, CurrencyCode currency)
        {
            //prepare
            _amount = amount;

            CashPaymentService service = new CashPaymentService(new CashDeviceMock(TestWork.CashAccepted));

            service.OnAcceptance += Service_OnAcceptedGood;
            
            Money money = Money.Create(amount, currency);

            // Perform
            service.CashAcceptance(money);

            // Pre-validation
            //Assert.Equal(amount, _payment.Amount, 6);

            

            // Post-validation

            
        }

        [Theory]
        [InlineData(100.0,CurrencyCode.RussianRouble)]
        public void Test_CashAcceptance_Bad(decimal amount,CurrencyCode currency)
        {
            //prepare
            _amount = amount;

            CashPaymentService service = new CashPaymentService(new CashDeviceMock(TestWork.BadCashAccepted));

            service.OnAcceptance += Service_OnAcceptedBad;

            Money money = Money.Create(amount, currency);

            //repform
            service.CashAcceptance(money);
        }

        [Fact]
        public void Test_CashTest()
        {
            //prepare
            CashPaymentService service = new CashPaymentService(new CashDeviceMock(TestWork.CashAccepted));

            service.OnTest += Service_OnTest;

            //perform
            service.Test();
        }

        [Fact]
        public void Test_DeviceStop()
        {
            //prepare
            CashPaymentService service = new CashPaymentService(new CashDeviceMock(TestWork.CashAccepted));

            service.OnStop += Service_OnStop;

            //perform
            service.StopDevice();
        }

        [Theory]
        [InlineData(99.9,CurrencyCode.RussianRouble,TestWork.GiveChanged)]
        [InlineData(98.9,CurrencyCode.RussianRouble,TestWork.BadGiveChanged)]
        [InlineData(95,CurrencyCode.RussianRouble,TestWork.BadCashAccepted)]
        [InlineData(95,CurrencyCode.RussianRouble,TestWork.CashAccepted)]
        public void Test_GiveChange(decimal amount,CurrencyCode currencyCode,TestWork type)
        {
            //prepare
            CashPaymentService service = new CashPaymentService(new CashDeviceMock(type));

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
            Assert.Null( e.Money);
            Assert.Null(e.Event);
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
            Assert.Equal(e.Level.ToString(), Utils.Abstractions.Events.EventItem.EventLevel.Info.ToString());
        }

        private void Service_OnTest(object sender, Abstractions.TestResultCash e)
        {
            Assert.Equal(TestResultError.None.ToString(), e.Result.ToString());
        }

        private void Service_OnAcceptedBad(object sender, EventCashReceive e)
        {
            Assert.Equal(e.Event.Level.ToString(), Utils.Abstractions.Events.EventItem.EventLevel.Error.ToString());

            Assert.Equal(_amount, e.Money.Value);
        }

        private void Service_OnAcceptedGood(object sender, EventCashReceive e)
        {
            Assert.Equal(e.Event.Level.ToString(), Utils.Abstractions.Events.EventItem.EventLevel.Info.ToString());

            Assert.Equal(_amount, e.Money.Value);
        }
    }
}
