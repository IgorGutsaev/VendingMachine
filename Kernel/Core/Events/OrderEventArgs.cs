using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions;
using System;
using System.Text.Json;

namespace Filuet.ASC.OnBoard.Kernel.Core
{
    public class OrderOpenEventArgs : OrderEventArgs { }

    public class OrderCloseEventArgs : OrderEventArgs { } // TODO: would be better to put inside an Order state, payment income, dispensing log

    public abstract class OrderEventArgs : EventArgs
    {
        public Order Order { get; set; }

        public override string ToString()
            => JsonSerializer.Serialize(Order, typeof(object), JsonSerializationOptions.EventPrettyOptions);
    }
}
