using Filuet.ASC.Kiosk.OnBoard.Ecommerce.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Core
{
    public class UvsEcommerceService : IEcommerceService
    {
        public PaymentSource Source => PaymentSource.UVS;

        public event EventHandler<ECommerceIncomeEventArgs> OnReceived;

        public event EventHandler<ECommercePaymentCancelledEventArgs> OnPaymentCancelled;

        private MockUvsAdapter _adapter = null;

        private Order.Abstractions.Order _order;

        public UvsEcommerceService()
        {
            _adapter = new MockUvsAdapter();
            _adapter.OnUvsPayment += (sender, e) => OnReceived?.Invoke(this, new ECommerceIncomeEventArgs { Income = Money.Create(e.Amount, _order.Amount.Currency) });
            _adapter.OnUvsOrderCancelled += (sender, e) => OnPaymentCancelled?.Invoke(this, new ECommercePaymentCancelledEventArgs { Message = e.Message });
        }

        public void FetchMoney(Order.Abstractions.Order order)
        {
            _order = order;
            bool created = _adapter.CreateOrder(order.Number, order.Customer, order.CustomerName, order.Amount.Value, null /* no matter*/);
            if (!created)
                throw new InvalidOperationException($"Unable to fetch money from UVS");
        }
    }
}
