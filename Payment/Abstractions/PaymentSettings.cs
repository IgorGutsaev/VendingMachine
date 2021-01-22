using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.OnBoard.Payment.Abstractions
{
    public abstract class BasePaymentSettings
    {
        public string Protocol { get; set; }

        public CurrencyCode Currency { get; set; }

        public decimal MinPayment { get; set; } = 0.01m;

        public decimal MaxPayment { get; set; } = 10000000m;

        /// <summary>
        /// 0 - Unlimited
        /// </summary>
        public decimal MaxRefund { get; set; } = 0m; // Unlimited
    }

    public class CashPaymentSettings : BasePaymentSettings
    {
        /// <summary>
        /// To pay with alternative currencies. E.g. Cambodia case: local riel and us dollar
        /// </summary>
        public CurrencyCode[] AdditionalCurrency { get; set; }

        public TimeSpan InsertionGap { get; set; } = TimeSpan.FromSeconds(60 * 2);
    }

    /// <summary>
    /// Card / QR code or other
    /// </summary>
    public class CashlessPaymentSettings : BasePaymentSettings
    {
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(60 * 2);
    }

    public class PaymentSettings
    {
        public string BaseCurrency { get; set; }
        public CashPaymentSettings[] Cash { get; private set; }
        public CashlessPaymentSettings[] Cashless { get; private set; }
    }
}
