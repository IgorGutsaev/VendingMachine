using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.OnBoard.Payment.Abstractions
{
    public class TotalChangeIssuedEventArgs : EventArgs
    {
        public Money ChangeAmount { get; set; }

        public Money ChangeIssued { get; set; }

        /// <summary>
        /// The change part that wasn't returned to the customer
        /// </summary>
        public Money ChangeDebt { get; set; }

        private TotalChangeIssuedEventArgs() { }

        public static TotalChangeIssuedEventArgs Create(Money changeAmount, Money changeIssued, Money changeDebt)
        {
            if (changeAmount == null || changeAmount == 0m)
                throw new ArgumentException("The change to issue is mandatory");

            if (changeIssued == null)
                throw new ArgumentException("The given change is mandatory");

            if (changeDebt == null)
                throw new ArgumentException("The change debt is mandatory");

            if (changeIssued + changeDebt != changeAmount)
                throw new Exception("The change given to the customer with change debt must be equals to total change amount");

            return new TotalChangeIssuedEventArgs { ChangeAmount = changeAmount, ChangeIssued = changeIssued, ChangeDebt = changeDebt };
        }

        public override string ToString() => $"Change has been issued: {ChangeIssued} out of {ChangeAmount}" +
            $"{(ChangeDebt.Value > 0m ? $"Change debit {ChangeDebt} (fetch your change from the staff)" : string.Empty)}";
    }
}
