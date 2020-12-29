using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.OnBoard.Payment.Abstractions
{
    public class PaymentCollectedEventArgs : EventArgs
    {
        public Money Credit { get; set; }

        public Money ChangeToIssue { get; set; }

        public static PaymentCollectedEventArgs Create(Money credit, Money change)
        {
            if (credit == null || credit == 0m)
                throw new ArgumentException("The inserted credit must be positive");

            if (change == null)
                throw new ArgumentException("The change to be issued must be specified non-negative");

            return new PaymentCollectedEventArgs { Credit = credit, ChangeToIssue = change };
        }

        public override string ToString() => $"Credit: {Credit}; ChangeToIssue: {ChangeToIssue}";
    }
}
