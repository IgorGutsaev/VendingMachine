using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Core.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMachineBuilder<TMachine, TTray, TBelt>(this IServiceCollection serviceCollection,
            Action<IStorePopulator<TMachine, TTray, TBelt>> builderAction)
             where TMachine : IStoreMachine<TTray, TBelt>, new()
             where TTray : IStoreTray<TBelt>, new()
             where TBelt : IStoreBelt, new()
        {
            StoreBuilder<TMachine, TTray, TBelt> builder = new StoreBuilder<TMachine, TTray, TBelt>();
            builderAction?.Invoke(builder);

            return serviceCollection
                .AddSingleton<IStoreBuilder<TMachine, TTray, TBelt>>(builder);
        }

        public static IServiceCollection AddSupplyDispenser(this IServiceCollection serviceCollection)
            => serviceCollection.AddSingleton<ISupplyDispenser>(TraceDecorator<ISupplyDispenser>.Create(new SupplyDispenser()))
            ; // Also add dispensing provider (jofemar)
    }
}
