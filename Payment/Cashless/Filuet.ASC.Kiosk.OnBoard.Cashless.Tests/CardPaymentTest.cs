using Filuet.ASC.Kiosk.OnBoard.Cashless.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashless.Abstractions.Events;
using Filuet.ASC.Kiosk.OnBoard.Cashless.Core;
using Filuet.Utils.Common.Business;
using System;
using Xunit;

namespace Filuet.ASC.Kiosk.OnBoard.Cashless.Tests
{
    public class CardPaymentTest
    {
        protected ICardPaymentService _cardPaymentService = new CardPaymentService();

        protected Money _amount;

        protected TestWorkCard _type;
        public CardPaymentTest()
        {
            _cardPaymentService.OnPayment += CardPaymentService_OnGoodPayment;
            _cardPaymentService.OnReturnPayment += CardPaymentService_OnGoodReturnPayment;
            _cardPaymentService.OnStop += CardPaymentService_OnGoodStop;
        }

        private void CardPaymentService_OnGoodStop(object sender, StopCardEventArgs e)
        {
            if (_type == TestWorkCard.StopPaymentGood)
            {
                Assert.False(e.Event.IsError);
            }
            else
            {
                Assert.True(e.Event.IsError);
            }
        }

        private void CardPaymentService_OnGoodReturnPayment(object sender, CardEventArgs e)
        {
            if (_type == TestWorkCard.FinishedPaymentGood)
            {
                Assert.False(e.Event.IsError);
            }
            else
            {
                Assert.True(e.Event.IsError);
            }
        }

        private void CardPaymentService_OnGoodPayment(object sender, CardEventArgs e)
        {
            if (_type == TestWorkCard.FinishedPaymentGood)
            {
                Assert.False(e.Event.IsError);
            }
            else
            {
                Assert.True(e.Event.IsError);
            }
        }

        [Fact]
        public void Test1()
        {
            Assert.Equal(1, 1);
        }

        [Theory]
        [InlineData(100,CurrencyCode.AustralianDollar,TestWorkCard.FinishedPaymentGood)]
        [InlineData(100, CurrencyCode.AustralianDollar, TestWorkCard.FinishedPaymentBad)]
        [InlineData(100, CurrencyCode.AustralianDollar, TestWorkCard.StartReturnPaymentBad)]
        [InlineData(100, CurrencyCode.AustralianDollar, TestWorkCard.StartedPaymentBad)]
        [InlineData(100, CurrencyCode.AustralianDollar, TestWorkCard.StopPaymentBad)]
        [InlineData(100, CurrencyCode.AustralianDollar, TestWorkCard.StopPaymentGood)]
        public void Test_StartPayment(decimal money,CurrencyCode currency,TestWorkCard type)
        {
            //prepare
            _type = type;

            _amount = Money.Create(money, currency);

            _cardPaymentService.AddCardDevice(new CardDeviceMock(type));

            _cardPaymentService.StartPayment(_amount);

            _cardPaymentService.RemoveCardDevice();

        }

        [Theory]
        [InlineData(100, CurrencyCode.AustralianDollar, TestWorkCard.FinishedPaymentGood)]
        [InlineData(100, CurrencyCode.AustralianDollar, TestWorkCard.FinishedPaymentBad)]
        [InlineData(100, CurrencyCode.AustralianDollar, TestWorkCard.StartReturnPaymentBad)]
        [InlineData(100, CurrencyCode.AustralianDollar, TestWorkCard.StartedPaymentBad)]
        [InlineData(100, CurrencyCode.AustralianDollar, TestWorkCard.StopPaymentBad)]
        [InlineData(100, CurrencyCode.AustralianDollar, TestWorkCard.StopPaymentGood)]
        public void Test_ReturnPayment(decimal money,CurrencyCode currency,TestWorkCard type)
        {
            //prepare
            _type = type;

            _amount = Money.Create(money, currency);

            _cardPaymentService.AddCardDevice(new CardDeviceMock(type));

            _cardPaymentService.StartReturnPayment(_amount);

            _cardPaymentService.RemoveCardDevice();
        }

        [Theory]
        [InlineData(TestWorkCard.FinishedPaymentGood)]
        [InlineData(TestWorkCard.FinishedPaymentBad)]
        [InlineData(TestWorkCard.StartReturnPaymentBad)]
        [InlineData(TestWorkCard.StartedPaymentBad)]
        [InlineData(TestWorkCard.StopPaymentBad)]
        [InlineData(TestWorkCard.StopPaymentGood)]
        public void Test_StopPayment(TestWorkCard type)
        {
            //prepare
            _type = type;

            _cardPaymentService.AddCardDevice(new CardDeviceMock(type));

            _cardPaymentService.StopPayment();

            _cardPaymentService.RemoveCardDevice();
        }
    }
}
