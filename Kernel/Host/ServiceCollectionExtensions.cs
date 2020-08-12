using Filuet.ASC.Kiosk;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Core;
using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.ASC.OnBoard.Kernel.Core;
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
using Filuet.Utils.Common.PosSettings;
using Filuet.ASC.Kiosk.OnBoard.SDK.Jofemar.VisionEsPlus;

namespace Filuet.ASC.OnBoard.Kernel.HostApp
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHardware(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddCompositeDispenser((sp) =>
                {
                    KioskSettings kioskSettings = sp.GetRequiredService<KioskSettings>();

                    return new CompositeDispenserBuilder().AddDispensers(() =>
                        kioskSettings.Dispenser.SlaveMachines.Select(x =>
                        {
                            switch (x.Model)
                            {
                                case "VisionEsPlus":
                                    return new VisionEsPlusDispenser(new VisionEsPlus(new VisionEsPlusSettings { SerialPortNumber = (ushort)x.Port }));
                                default:
                                    throw new ArgumentException("Unknown dispenser model");
                            }
                        })
                    ).Build();
                })
                .AddCashPayment()
                .AddEventMediation((sp, broker) =>
                {
                    broker.AppendProducer(sp.GetRequiredService<ICashPaymentService>() as IEventProducer);
                    broker.AppendProducer(sp.GetRequiredService<ICompositeDispenser>() as IEventProducer);
                    broker.AppendProducer(sp.GetRequiredService<IStorageService>() as IEventProducer);
                    broker.AppendProducer(sp.GetRequiredService<IAttendant>() as IEventProducer);
                })
                .AddSingleton((sp) =>
                    new EventConsumer()
                        .AppendWriter<ICashPaymentService>(new EventWriter<ICashPaymentService>(sp.GetRequiredService<ILogger<ICashPaymentService>>()))
                        .AppendWriter<ICompositeDispenser>(new EventWriter<ICompositeDispenser>(sp.GetRequiredService<ILogger<ICompositeDispenser>>()))
                        .AppendWriter<IStorageService>(new EventWriter<IStorageService>(sp.GetRequiredService<ILogger<IStorageService>>()))
                        .AppendWriter<IAttendant>(new EventWriter<IAttendant>(sp.GetRequiredService<ILogger<IAttendant>>())));
        }
    }
}
