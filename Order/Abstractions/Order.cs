using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Filuet.Utils.Common.Business;

namespace Filuet.ASC.Kiosk.OnBoard.Order.Abstractions
{
    public class Order
    {
        public Guid Id { get => _id; }

        public DateTime Timestamp { get => _timestamp; } 

        internal Order()
        {
            _id = new Guid();
            _timestamp = DateTime.Now;
        }

        public Money Amount { get; internal set; }

        public IEnumerable<OrderItem> Items { get; internal set; }

        public override string ToString() => Amount.ToString();

        private readonly Guid _id;
        private readonly DateTime _timestamp;
    }
}
