using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.OnBoard.Kernel.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAttendant(this IServiceCollection serviceCollection)
            => serviceCollection.AddSingleton(sp =>
                    TraceDecorator<IAttendant>.Create(new Attendant()));
    }
}
