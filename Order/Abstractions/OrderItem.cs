﻿using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Order.Abstractions
{
    public class OrderItem
    {
        /// <summary>
        /// Unique identifier of product. E.g. SKU
        /// </summary>
        public string ProductUID { get; protected set; }

        public uint Quantity { get; protected set; }

        protected OrderItem() { }

        /// <summary>
        /// Create single order line
        /// </summary>
        /// <param name="productUid">Unique identifier of product. E.g. SKU</param>
        /// <param name="amount">Unit cost</param>
        /// <returns></returns>
        public static OrderItem Create(string productUid, uint quantity)
        {
            if (string.IsNullOrWhiteSpace(productUid))
                throw new ArgumentException("Product must be specified");

            if (quantity == 0)
                throw new ArgumentException("Quantity must be positive");

            return new OrderItem { ProductUID = productUid, Quantity = quantity};
        }

        public override string ToString() => $"{ProductUID} [{Quantity}]";
    }
}
