using Filuet.ASC.Kiosk.OnBoard.Cashless.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Microsoft.Extensions.DependencyInjection;

namespace Filuet.ASC.Kiosk.OnBoard.Cashless.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCardPayment(this IServiceCollection serviceCollection)
            => serviceCollection.AddSingleton(TraceDecorator<ICardPaymentService>.Create(new CardPaymentService()));
    }
}
