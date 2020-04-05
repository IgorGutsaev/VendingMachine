using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.Utils.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStorageService(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<IAscUnitOfWork, AscBaseUnitOfWork>()
                .AddSingleton<IKioskStorageService, KioskStorageService>();
        }

        public static IServiceCollection AddCacheContext(this IServiceCollection serviceCollection, Action<LocalStorageSettings> setupAction = null)
        {
            return serviceCollection
                .AddTransient(sp => new LocalStorageContext(setupAction?.CreateTargetAndInvoke()));////, sp.GetRequiredService<IEventLogger>()));
        }
    }
}
