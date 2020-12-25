using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Order.Abstractions
{
    public class OrderLine : OrderItem
    {
        public uint Quantity { get; private set; }

        public Money TotalAmount { get; protected set; }

        private OrderLine() : base() { }

        /// <summary>
        /// Create order line
        /// </summary>
        /// <param name="productUid">Unique identifier of product. E.g. SKU</param>
        /// <param name="quantity">quantity of order line</param>
        /// <param name="amount">Unit cost</param>
        /// <param name="totalAmount">Total cost of line</param>
        /// <returns></returns>
        public static OrderLine Create(string productUid, uint quantity, Money amount, Money totalAmount)
        {
            OrderItem item = OrderItem.Create(productUid, amount);

            if (quantity == 0)
                throw new ArgumentException("Quantity must be positive");

            if (totalAmount == null || totalAmount.Value < 0m)
                throw new ArgumentException("Total amount is mandatory");

            return new OrderLine { ProductUID = item.ProductUID, Quantity = quantity, Amount = item.Amount, TotalAmount = item.Amount };
        }

        /// <summary>
        /// Create order line with quantity equals to 1
        /// </summary>
        /// <param name="productUid">Unique identifier of product. E.g. SKU</param>
        /// <param name="amount">Unit cost</param>
        /// <returns></returns>
        new public static OrderLine Create(string productUid, Money amount)
        {
            OrderItem item = OrderItem.Create(productUid, amount);

            return new OrderLine { ProductUID = item.ProductUID, Quantity = 1, Amount = item.Amount, TotalAmount = item.Amount };
        }

        public override string ToString() => $"{base.ToString()} x{Quantity}";
    }
}
