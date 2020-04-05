﻿using Filuet.ASC.Kiosk;
using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Core;
using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.Utils.Abstractions.Event;
using Filuet.Utils.Abstractions.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Filuet.ASC.OnBoard.Kernel.HostApp
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHardware(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSupplyDispenser()
                .AddEventMediation<IKioskEventProducer>()
                .AddSingleton((sp) =>
                    new EventConsumer()
                        .AppendWriter<ISupplyDispenser>(new EventWriter<ISupplyDispenser>(sp.GetRequiredService<ILogger<ISupplyDispenser>>()))
                        .AppendWriter<IKioskStorageService>(new EventWriter<IKioskStorageService>(sp.GetRequiredService<ILogger<IKioskStorageService>>())));
        }
    }
}
