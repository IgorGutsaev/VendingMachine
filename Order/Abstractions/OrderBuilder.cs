using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions.Enums;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Order.Abstractions
{
    public class OrderBuilder
    {
        private IEnumerable<OrderLine> _items;
        private Money _amount;
        private string _orderNumber;
        private string _customer;
        private GoodsObtainingMethod _method;

        public OrderBuilder WithObtainingMethod(GoodsObtainingMethod method)
        {
            _method = method;
            return this;
        }

        public OrderBuilder WithHeader(string orderNumber, string customer)
        {
            if (string.IsNullOrWhiteSpace(orderNumber) || orderNumber.Trim().Length < 4)
                throw new ArgumentException("Order number is mandatory");

            if (string.IsNullOrWhiteSpace(customer) || customer.Trim().Length < 4)
                throw new ArgumentException("Customer is mandatory");

            _orderNumber = orderNumber.Trim();
            _customer = customer.Trim();

            return this;
        }

        public OrderBuilder WithItems(params OrderLine[] items)
        {
            if (items == null || !items.Any())
                throw new ArgumentException("Items must be specified");

            if (items.GroupBy(x => x.ProductUID).Any(x => x.Count() > 1))
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
            if (amount.Value < 0)
                throw new ArgumentException("Order amount must be positive");

            if (_items != null)
            {
                CurrencyCode itemsCurrency = _items.GroupBy(x => x.Amount.Currency).Select(x => x.Key).Distinct().First();

                if (amount != null && (Math.Abs(_items.Sum(x => x.Amount.Value) - amount.Value) >= 1m || amount.Currency != itemsCurrency))
                    throw new ArgumentException("Order amount is not equals to order items summ or order currency different from order items");
            }

            _amount = amount;

            return this;
        }

        public Order Build()
        {
            if (_items == null || _items.Count() == 0)
                throw new ArgumentException("Items must be specified");

            if (_amount.Value < 0)
                throw new ArgumentException("Order amount must be positive");

            if (string.IsNullOrWhiteSpace(_orderNumber) || _orderNumber.Trim().Length < 4)
                throw new ArgumentException("Order number is mandatory");

            if (string.IsNullOrWhiteSpace(_customer) || _customer.Trim().Length < 4)
                throw new ArgumentException("Customer is mandatory");

            return new Order { Items = _items, Amount = _amount, Customer = _customer, Number = _orderNumber, Obtaining = _method };
        }
    }
}
