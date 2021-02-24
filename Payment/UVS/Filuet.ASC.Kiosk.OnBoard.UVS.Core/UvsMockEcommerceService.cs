using Filuet.ASC.Kiosk.OnBoard.Cashbox.Core;
using Filuet.ASC.Kiosk.OnBoard.Ecommerce.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.ASC.OnBoard.Payment.Abstractions.Interfaces;
using Filuet.Utils.Common.Business;
using Filuet.Utils.Extensions;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Core
{
    public class UvsMockEcommerceService : IEcommerceService
    {
        public UvsMockEcommerceService(ICurrencyConverter currencyConverter, Action<ECommerceHandleSettings> setupAction)
        {
            _currencyConverter = currencyConverter;
            _settings = setupAction?.CreateTargetAndInvoke();

            _adapter = new MockUvsAdapter();
            _adapter.OnUvsPayment += (sender, e) =>
                OnReceived?.Invoke(this, new ECommerceIncomeEventArgs {
                    Income = MoneyNaturalized.Create(_currencyConverter.Convert(Money.Create(e.Amount, _order.Amount.Currency), _settings.BaseCurrency),
                        Money.Create(e.Amount, _order.Amount.Currency)) });
            _adapter.OnUvsOrderCancelled += (sender, e) =>
                OnPaymentCancelled?.Invoke(this, new ECommercePaymentCancelledEventArgs { Message = e.Message });
        }

        public void FetchMoney(Order order)
        {
            _order = order;
            bool created = _adapter.CreateOrder(order.Number, order.Customer, order.CustomerName, order.Amount.Value, null /* no matter*/);
            if (!created)
                throw new InvalidOperationException($"Unable to fetch money from UVS");
        }

        public event EventHandler<ECommerceIncomeEventArgs> OnReceived;
        public event EventHandler<ECommercePaymentCancelledEventArgs> OnPaymentCancelled;

        public PaymentSource Source => PaymentSource.UVS;
        private MockUvsAdapter _adapter = null;
        private Order _order;
        private readonly ICurrencyConverter _currencyConverter;
        private readonly ECommerceHandleSettings _settings;
    }
}
