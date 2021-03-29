using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions.Enums;
using Filuet.Utils.Extensions;
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

    public class OrderSlipEventArgs : EventArgs
    {
        public string Order { get; private set; }

        public SlipType SlipType { get; private set; }

        public string SlipImageFile { get; private set; }

        public static OrderSlipEventArgs Create(string orderNumber, SlipType type, string slipImageFile) {
            if (string.IsNullOrWhiteSpace(orderNumber))
                throw new ArgumentException("Order number is mandatory");

            OrderSlipEventArgs result = new OrderSlipEventArgs {
                Order = orderNumber.Trim(),
                SlipType = type,
                SlipImageFile = slipImageFile.Trim()
            };

            return result;
        }

        public override string ToString()
            => JsonSerializer.Serialize(new { Order, SlipType = SlipType.GetCode(), ImageFile = SlipImageFile }, typeof(object), JsonSerializationOptions.EventPrettyOptions);
    }
}
