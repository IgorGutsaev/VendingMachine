using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Catalog.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Filuet.ASC.Kiosk.OnBoard.Catalog.Service
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCatalog(this IServiceCollection serviceCollection)
            => serviceCollection.AddSingleton(sp =>
                    TraceDecorator<ICatalogService>.Create(new CatalogService()));
    }
}
