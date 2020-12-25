using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.OnBoard.Payment.Abstractions.Interfaces
{
    public interface ICurrencyConverter
    {
        Money Convert(Money money, CurrencyCode destination);
    }
}
