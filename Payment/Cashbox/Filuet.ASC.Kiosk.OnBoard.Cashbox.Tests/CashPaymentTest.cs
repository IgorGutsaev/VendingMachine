using System;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Core;
using Filuet.Utils.Common.Business;
using Xunit;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Tests
{
    public class CashPaymentTest
    {


        public CashPaymentTest()
        {
            

        }

        [Fact]
        public void Test1()
        {

        }

        [Theory]
        [InlineData(100.0,CurrencyCode.RussianRouble)]
        public void CashAcceptanceTest(decimal amount, CurrencyCode currency)
        {
            CashPayment _payment = new CashPayment(new CashDeviceMock(TestWork.CashAccepting));

        //prepare
        Money money = Money.Create(amount, currency);

            _payment.CashAcceptance(money);

            // Pre-validation
            Assert.Equal(amount, _payment.Amount, 6);

            // Perform

            // Post-validation

            
        }
    }
}
