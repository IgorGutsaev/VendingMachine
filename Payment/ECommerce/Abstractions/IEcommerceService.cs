using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Ecommerce.Abstractions
{
    public interface IEcommerceServices
    {
        IEcommerceService this[PaymentSource source] { get; }

        IEnumerable<IEcommerceService> Services { get; }

        void Add(IEcommerceService service);
    }

    public interface IEcommerceService
    {
        PaymentSource Source { get; }

        event EventHandler<ECommerceIncomeEventArgs> OnReceived;

        event EventHandler<ECommercePaymentCancelledEventArgs> OnPaymentCancelled;

        void FetchMoney(Filuet.ASC.Kiosk.OnBoard.Order.Abstractions.Order order);
    }
}
