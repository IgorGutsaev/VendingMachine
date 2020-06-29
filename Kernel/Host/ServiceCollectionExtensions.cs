using Filuet.ASC.Kiosk;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Core;
using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Core;
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
            return serviceCollection
                .AddSupplyDispenser()
                .AddCashPayment()
                .AddEventMediation((sp, broker) => {
                    broker.AppendProducer(sp.GetRequiredService<ICashPaymentService>() as IEventProducer);
                    broker.AppendProducer(sp.GetRequiredService<ISupplyDispenser>() as IEventProducer);
                    broker.AppendProducer(sp.GetRequiredService<IStorageService>() as IEventProducer);
                })          
                .AddSingleton((sp) =>
                    new EventConsumer()
                        .AppendWriter<ICashPaymentService>(new EventWriter<ICashPaymentService>(sp.GetRequiredService<ILogger<ICashPaymentService>>()))
                        .AppendWriter<ISupplyDispenser>(new EventWriter<ISupplyDispenser>(sp.GetRequiredService<ILogger<ISupplyDispenser>>()))
                        .AppendWriter<IStorageService>(new EventWriter<IStorageService>(sp.GetRequiredService<ILogger<IStorageService>>())));
        }
    }
}
