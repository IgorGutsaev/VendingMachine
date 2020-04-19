using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Order.Abstractions
{
    public class OrderBuilder
    {
        private IEnumerable<OrderItem> _items;
        private Money _amount;

        public OrderBuilder WithItems(IEnumerable<OrderItem> items)
        {
            if (items == null || !items.Any())
                throw new ArgumentException("Items must be specified");

            if (items.GroupBy(x => x.Product).Any(x => x.Count() > 1))
                throw new ArgumentException("Duplicates founded in order items");

            if (items.Any(x => x.Amount == null || x.Amount.Value < 0)) // An item could costs 0 (a gift for example)
                throw new ArgumentException("Invalid item(s) detected");

            if (items.GroupBy(x => x.Amount.Currency).Select(x => x.Key).Distinct().Count() > 1)
                throw new ArgumentException("Multiply currencies have been detected in order items");

            _items = items;

            CurrencyCode itemsCurrency = items.GroupBy(x => x.Amount.Currency).Select(x => x.Key).Distinct().First();

            if (_amount != null && (Math.Abs(items.Sum(x => x.Amount.Value) - _amount.Value) >= 1m || _amount.Currency != itemsCurrency))
                throw new ArgumentException("Order amount is not equals to order items summ or order currency different from order items");

            return this;
        }

        public OrderBuilder WithTotalAmount(Money amount)
        {
            if (amount.Value <= 0)
                throw new ArgumentException("Order amount must be positive");

            if (_items != null)
            {
                CurrencyCode itemsCurrency = _items.GroupBy(x => x.Amount.Currency).Select(x => x.Key).Distinct().First();

                if (amount != null && (Math.Abs(_items.Sum(x => x.Amount.Value) - amount.Value) >= 1m || amount.Currency != itemsCurrency))
                    throw new ArgumentException("Order amount is not equals to order items summ or order currency different from order items");
            }

            return this;
        }

        public Order Build() => new Order { Items = _items, Amount = _amount };
    }
}
