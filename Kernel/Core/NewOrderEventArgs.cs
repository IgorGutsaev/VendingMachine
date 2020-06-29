using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.OnBoard.Kernel.Core
{
    public class NewOrderEventArgs : EventArgs
    {
        public Order Order { get; set; }
    }
}
