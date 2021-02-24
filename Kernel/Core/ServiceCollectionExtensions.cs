using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions;
using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.ASC.OnBoard.Payment.Abstractions;
using Filuet.ASC.OnBoard.Payment.Abstractions.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Filuet.ASC.OnBoard.Kernel.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAttendant(this IServiceCollection serviceCollection)
            => serviceCollection
            .AddSingleton<ICurrencyConverter, MockCurrencyConverter>()
            .AddSingleton(sp =>
                    TraceDecorator<IAttendant>.Create(new Attendant(sp.GetRequiredService<IPaymentProvider>(),
                        sp.GetRequiredService<ICompositeDispenser>(),
                        sp.GetRequiredService<ISlipService>())))
            .AddSingleton(sp => new OrderingMediator(sp.GetRequiredService<IAttendant>(), sp.GetRequiredService<IStorageService>()));
    }
}
