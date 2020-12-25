using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.OnBoard.Payment.Abstractions;
using Filuet.ASC.OnBoard.Payment.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPaymentProvider(this IServiceCollection serviceCollection)
            => serviceCollection.AddTransient<PaymentMediator>()
                .AddSingleton(sp =>
                    TraceDecorator<IPaymentProvider>.Create(new PaymentProvider()));

    }
}
