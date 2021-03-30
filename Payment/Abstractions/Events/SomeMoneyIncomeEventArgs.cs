using Filuet.Utils.Common.Business;
using Filuet.Utils.Common.Converters.Json;
using Filuet.Utils.Extensions;
using System;
using System.Text.Json.Serialization;

namespace Filuet.ASC.OnBoard.Payment.Abstractions
{
    public class SomeMoneyIncomeEventArgs : EventArgs
    {
        public PaymentSource Source { get; set; }

        [JsonConverter(typeof(MoneyNaturalizedToStringJsonConverter))]
        public MoneyNaturalized SomeMoneyIncome { get; set; }

        public static SomeMoneyIncomeEventArgs Create(PaymentSource source, MoneyNaturalized money)
            => new SomeMoneyIncomeEventArgs { SomeMoneyIncome = money, Source = source };

        public override string ToString() => $"Income: {SomeMoneyIncome}; Source: {Source.GetCode()}";
    }
}