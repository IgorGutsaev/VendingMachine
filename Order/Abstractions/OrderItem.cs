using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Order.Abstractions
{
    public class OrderItem
    {
        public string Product { get; private set; }
        public uint Quantity { get; private set; }
        public Money Amount { get; private set; }

        public OrderItem(string product, uint qty, Money amount)
        {
            Product = product;
            Quantity = qty;
            Amount = amount;
        }
    }
}
