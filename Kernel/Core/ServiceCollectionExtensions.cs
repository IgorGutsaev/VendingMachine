using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.ASC.OnBoard.Payment.Abstractions;
using Filuet.ASC.OnBoard.Payment.Abstractions.Interfaces;
using Filuet.Utils.Abstractions.Platform.Settings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.OnBoard.Kernel.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAttendant(this IServiceCollection serviceCollection)
            => serviceCollection
            .AddSingleton<ICurrencyConverter, MockCurrencyConverter>()
            .AddSingleton(sp =>
                    TraceDecorator<IAttendant>.Create(new Attendant(sp.GetRequiredService<IPaymentProvider>())))
            .AddSingleton(sp => new OrderingMediator(sp.GetRequiredService<IAttendant>(), sp.GetRequiredService<IStorageService>()));
    }
}
