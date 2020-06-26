using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions
{
    [Serializable]
    public class CashPaymentDetail:IdentifiableEntity<string>
    {
        public decimal Amount { get; set; }

        public string Result { get; set; }

        public string Type { get; set; }

        public DateTime Timestamp { get; set; }

        protected CashPaymentDetail()
        {
            Id = Guid.NewGuid().ToString();
        }

        public static CashPaymentDetail Create(decimal amount = 0.0m,string result = "",string type = "",DateTime? timestamp = null)
        {
            if (amount.Equals(0.0m))
                throw new ArgumentException("Unable amount cash = 0");

            if (string.IsNullOrEmpty(result))
                throw new ArgumentException("Do not have result operation with cash");

            if (string.IsNullOrEmpty(type))
                throw new ArgumentException("Do not have type operation with cash");

            return new CashPaymentDetail() { Amount = amount, Result = result, Type = type, Timestamp = timestamp.HasValue ? timestamp.Value : DateTime.UtcNow };
        }
    }
}
