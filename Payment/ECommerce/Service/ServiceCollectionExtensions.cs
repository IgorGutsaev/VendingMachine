using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Ecommerce.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Ecommerce.Service
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEcommerce(this IServiceCollection serviceCollection, Func<IServiceProvider, IEcommerceServices, IEcommerceServices> setupAction)
            => serviceCollection.AddSingleton(sp => setupAction(sp, TraceDecorator<IEcommerceServices>.Create(new EcommerceServices())));
    }
}
