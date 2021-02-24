using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.OnBoard.Payment.Abstractions
{
    public class FetchMoneyEventArgs : EventArgs
    {
        public PaymentSource Source { get; set; }

        public Order Order { get; set; }
    }
}
