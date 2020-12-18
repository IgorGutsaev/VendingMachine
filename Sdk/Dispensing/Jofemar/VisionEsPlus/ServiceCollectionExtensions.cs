using System;
using Microsoft.Extensions.DependencyInjection;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Core;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Tests.Entities;

namespace Filuet.ASC.OnBoard.Kernel.HostApp
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEsPlusStorage(this IServiceCollection serviceCollection
            , Action<ILayoutBuilder<VisionEspTray, VisionEspBelt>> setupStorage
            , Func<ILayout, bool> validateAction = null)
        {
            return serviceCollection
                .AddLayoutBuilder<VisionEspTray, VisionEspBelt>(setupStorage)
                .AddSingleton<ILayout>((sp) =>
                {
                    var builder = sp.GetService<ILayoutBuilder<VisionEspTray, VisionEspBelt>>();
                    return builder.Build(validateAction);
                });
        }
    }
}
