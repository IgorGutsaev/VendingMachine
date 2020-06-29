using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.Utils.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStorage(this IServiceCollection serviceCollection)
            => serviceCollection.AddTransient<IAscUnitOfWork, AscBaseUnitOfWork>()
                .AddSingleton(sp =>
                    TraceDecorator<IStorageService>.Create(new StorageService(sp.GetRequiredService<IAscUnitOfWork>())));

        public static IServiceCollection AddCacheContext(this IServiceCollection serviceCollection, Action<LocalStorageSettings> setupAction = null)
                => serviceCollection.AddTransient(sp => new LocalStorageContext(setupAction?.CreateTargetAndInvoke()));
    }
}
