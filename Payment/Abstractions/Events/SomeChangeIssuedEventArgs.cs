using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.OnBoard.Payment.Abstractions
{
    public class SomeChangeIssuedEventArgs : EventArgs
    {
        public MoneyNaturalized SomeChange { get; set; }

        private SomeChangeIssuedEventArgs() { }

        public static SomeChangeIssuedEventArgs Create(MoneyNaturalized change)
        {
            if (change == null || change.Native == 0m)
                throw new ArgumentException("The change has been given must be positive");

            return new SomeChangeIssuedEventArgs { SomeChange = change };
        }

        public override string ToString() => $"Change has been issued: {SomeChange}";
    }
}