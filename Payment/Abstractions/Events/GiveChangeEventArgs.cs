using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.OnBoard.Payment.Abstractions
{
    public class GiveChangeEventArgs : EventArgs
    {
        public Money ChangeAmount { get; set; }

        private GiveChangeEventArgs() { }

        public static GiveChangeEventArgs Create(Money change)
        {
            if (change == null || change == 0m)
                throw new ArgumentException("The change to issue must be positive");

            return new GiveChangeEventArgs { ChangeAmount = change };
        }

        public override string ToString() => $"Change: {ChangeAmount}";
    }
}
