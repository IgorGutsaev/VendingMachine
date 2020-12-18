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
                , Action<ILayoutBuilder> builderAction)
            where TTray : Tray, new()
            where TBelt : Belt, new()
        {
            LayoutBuilder builder = new LayoutBuilder();
            builderAction?.Invoke(builder);

            return serviceCollection
                .AddSingleton<ILayoutBuilder>(builder);
        }

        public static IServiceCollection AddCompositeDispenser(this IServiceCollection serviceCollection, Func<IServiceProvider, ICompositeDispenser> dispenserSetup)
            => serviceCollection.AddSingleton<ICompositeDispenser>((sp) => TraceDecorator<ICompositeDispenser>.Create(dispenserSetup(sp)));

        public static IServiceCollection AddLayout(this IServiceCollection serviceCollection, Func<IServiceProvider, ILayout> layoutSetup)
            => serviceCollection.AddSingleton<ILayout>((sp) => TraceDecorator<ILayout>.Create(layoutSetup(sp)));
    }
}
