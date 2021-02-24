using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Filuet.ASC.OnBoard.Kernel.Core
{
    public class OrderOpenEventArgs : OrderEventArgs { }

    public class OrderCloseEventArgs : OrderEventArgs
    {
        [JsonIgnore]
        new public Order Order { get; set; }

        public override string ToString()
            => JsonSerializer.Serialize(new { Order = Order?.Number }, typeof(object), JsonSerializationOptions.EventPrettyOptions);
    } 

    public abstract class OrderEventArgs : EventArgs
    {
        public Order Order { get; set; }

        public override string ToString()
            => JsonSerializer.Serialize(Order, typeof(object), JsonSerializationOptions.EventPrettyOptions);
    }
}
