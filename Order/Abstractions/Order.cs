using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using Filuet.Utils.Common.Business;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;

namespace Filuet.ASC.Kiosk.OnBoard.Order.Abstractions
{
    public class Order
    {
        public Guid Id { get => _id; }

        public string Number { get; internal set; }

        public string Customer { get; internal set; }

        public DateTime Timestamp { get => _timestamp; } 

        internal Order()
        {
            _id = Guid.NewGuid();
            _timestamp = DateTime.Now;
        }

        public Money Amount { get; internal set; }

        public IEnumerable<OrderLine> Items { get; internal set; }

        public override string ToString() =>  JsonSerializer.Serialize(this, typeof(object), JsonSerializationOptions.EventPrettyOptions);

        private readonly Guid _id;
        private readonly DateTime _timestamp;
    }
}
