using System;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Events
{
    public class UvsIncomeEventArgs : EventArgs
    {
        public int PaymentId { get; set; }

        public string Method { get; set; }
        
        public decimal Amount { get; set; }

        public static UvsIncomeEventArgs Create(int paymentId, string method, decimal amount)
        {
            StringBuilder sb = new StringBuilder();

            if (paymentId <= 0)
                sb.AppendLine("Payment id is mandatory");

            if (string.IsNullOrWhiteSpace(method))
                sb.AppendLine("Payment method is mandatory");

            if (amount <= 0m)
                sb.AppendLine("Amount is mandatory");

            if (sb.Length != 0)
                throw new ArgumentException(sb.ToString());

            return new UvsIncomeEventArgs { PaymentId = paymentId, Method = method.Trim(), Amount = amount };
        }
    }
}
