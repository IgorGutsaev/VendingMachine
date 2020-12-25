using Filuet.ASC.OnBoard.Payment.Abstractions.Interfaces;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.OnBoard.Payment.Abstractions
{
    public class MockCurrencyConverter : ICurrencyConverter
    {
        /// <summary>
        /// 1 to 1 freak conversion
        /// </summary>
        /// <param name="money"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public Money Convert(Money money, CurrencyCode destination)
        {
            if (money.Currency == CurrencyCode.USDollar && destination == CurrencyCode.RussianRouble)
                return Money.Create(money.Value * 75, destination);

            return Money.Create(money.Value, destination);
        }
    }
}
