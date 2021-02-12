﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using Filuet.Utils.Common.Business;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using System.Text.Json.Serialization;
using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions.Enums;
using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions.Converters;

namespace Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions
{
    public class Order
    {
        [JsonIgnore]
        public Guid Id { get => _id; }

        public string Number { get; internal set; }

        public string Customer { get; internal set; }

        public string CustomerName { get; internal set; }

        public Locale Location { get; internal set; }

        public DateTime Timestamp { get => _timestamp; }

        [JsonConverter(typeof(GoodsObtainingMethodConverter))]
        public GoodsObtainingMethod Obtaining { get; internal set; } = GoodsObtainingMethod.Warehouse;

        internal Order()
        {
            _id = Guid.NewGuid();
            _timestamp = DateTime.Now;
        }

        /// <summary>
        /// Order total
        /// </summary>
        public Money Amount { get; internal set; }

        public IEnumerable<OrderLine> Items { get; internal set; }

        public override string ToString() =>  JsonSerializer.Serialize(this, typeof(object), JsonSerializationOptions.EventPrettyOptions);

        private readonly Guid _id;

        private readonly DateTime _timestamp;
    }
}
