using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Ecommerce.Abstractions
{
    public class ECommercePaymentCancelledEventArgs : EventArgs
    {
        public string Message { get; set; } 
    }
}
