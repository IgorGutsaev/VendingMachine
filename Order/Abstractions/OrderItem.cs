using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Order.Abstractions
{
    public class OrderItem
    {
        /// <summary>
        /// Unique identifier of product. E.g. SKU
        /// </summary>
        public string ProductUID { get; protected set; }

        /// <summary>
        /// Unit cost
        /// </summary>
        public Money Amount { get; protected set; }

        protected OrderItem() { }

        /// <summary>
        /// Create single order line
        /// </summary>
        /// <param name="productUid">Unique identifier of product. E.g. SKU</param>
        /// <param name="amount">Unit cost</param>
        /// <returns></returns>
        public static OrderItem Create(string productUid, Money amount)
        {
            if (string.IsNullOrWhiteSpace(productUid))
                throw new ArgumentException("Product must be specified");

            if (amount == null || amount.Value < 0m)
                throw new ArgumentException("Amount is mandatory");

            return new OrderItem { ProductUID = productUid, Amount = amount };
        }

        public override string ToString() => $"{ProductUID} [{Amount}]";
    }
}
