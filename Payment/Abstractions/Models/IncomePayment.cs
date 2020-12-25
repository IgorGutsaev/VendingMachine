using Filuet.Utils.Common.Business;
using Filuet.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.OnBoard.Payment.Abstractions.Models
{
    /// <summary>
    /// Customer's money income
    /// </summary>
    public class IncomePayment
    {
        public PaymentMethod Method { get; internal set; }

        public Money Amount { get; internal set; }

        public override string ToString() => $"{Amount} by {Method.GetDescription()}";
    }
}
