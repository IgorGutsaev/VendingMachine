using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.OnBoard.Payment.Abstractions
{
    public abstract class MoneyEventArgs : EventArgs
    {
        public Money Value { get; set; }
    }
}
