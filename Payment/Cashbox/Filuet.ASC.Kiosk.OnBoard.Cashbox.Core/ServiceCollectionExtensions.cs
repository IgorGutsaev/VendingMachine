using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCashPayment(this IServiceCollection serviceCollection, Func<IServiceProvider, ICashPaymentService, ICashPaymentService> setupAction)
            => serviceCollection.AddSingleton(sp => setupAction(sp, TraceDecorator<ICashPaymentService>.Create(new CashPaymentService())));
    }
}
