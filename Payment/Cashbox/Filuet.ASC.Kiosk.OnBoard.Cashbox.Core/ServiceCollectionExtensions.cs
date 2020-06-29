using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Microsoft.Extensions.DependencyInjection;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCashPayment(this IServiceCollection serviceCollection)
        => serviceCollection.AddSingleton(TraceDecorator<ICashPaymentService>.Create(new CashPaymentService())); 
    }
}
