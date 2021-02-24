using Filuet.ASC.Kiosk.OnBoard.Catalog.Abstractions.Services;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions;
using Filuet.Utils.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.SlipService
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSlipService(this IServiceCollection serviceCollection, Action<SlipServiceSettings> setupAction)
        {
            SlipServiceSettings slipSettings = setupAction?.CreateTargetAndInvoke();

            return serviceCollection.AddSingleton<ISlipRepository>(new SlipRepository(slipSettings.SlipComponentsRepositoryPath))
                .AddSingleton((sp) => TraceDecorator<ISlipService>.Create(new SlipService(sp.GetRequiredService<ISlipRepository>(), sp.GetRequiredService<ICatalogService>(), slipSettings)));
        }
    }
}
