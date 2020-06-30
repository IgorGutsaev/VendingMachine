using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Order.Abstractions
{
    public class OrderItem
    {
        public string Product { get; protected set; }

        public Money Amount { get; protected set; }

        protected OrderItem() { }

        public static OrderItem Create(string product, Money amount)
        {
            if (string.IsNullOrWhiteSpace(product))
                throw new ArgumentException("Product must be specified");

            if (amount == null || amount.Value < 0m)
                throw new ArgumentException("Amount must be specified");

            return new OrderItem { Product = product, Amount = amount };
        }

        public override string ToString() => $"{Product} [{Amount}]";
    }
}
