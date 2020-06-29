using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Order.Abstractions
{
    public class OrderPosition : OrderItem
    {
        public uint Quantity { get; private set; }

        private OrderPosition() : base() { }

        public static OrderPosition Create(string product, uint qty, Money amount)
        {
            OrderItem item = OrderItem.Create(product, amount);

            if (qty == 0)
                throw new ArgumentException("Quantity must be positive");

            return new OrderPosition { Product = item.Product, Quantity = qty, Amount = item.Amount };
        }

        public override string ToString() => $"{base.ToString()} x{Quantity}";
    }
}
