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
        public static IServiceCollection AddLayoutBuilder<TTray, TBelt>(this IServiceCollection serviceCollection
                , Action<ILayoutBuilder<TTray, TBelt>> builderAction)
            where TTray : Tray, new()
            where TBelt : Belt, new()
        {
            LayoutBuilder<TTray, TBelt> builder = new LayoutBuilder<TTray, TBelt>();
            builderAction?.Invoke(builder);

            return serviceCollection
                .AddSingleton<ILayoutBuilder<TTray, TBelt>>(builder);
        }

        public static IServiceCollection AddCompositeDispenser(this IServiceCollection serviceCollection, Func<IServiceProvider, ICompositeDispenser> dispenserSetup)
            => serviceCollection.AddSingleton<ICompositeDispenser>((sp) => TraceDecorator<ICompositeDispenser>.Create(dispenserSetup(sp)));

        public static IServiceCollection AddMap(this IServiceCollection serviceCollection, Func<IServiceProvider, ILayout> layoutSetup)
            => serviceCollection.AddSingleton<ILayout>((sp) => TraceDecorator<ILayout>.Create(layoutSetup(sp)));
    }
}
