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
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Filuet.Utils.Abstractions.Communication;
using Filuet.Utils.Communication;

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

                    if (kioskSettings.Dispenser.Mode == DeviceUseCase.Off)
                        return null;

                    return new CompositeDispenserBuilder().AddDispensers(() =>
                        kioskSettings.Dispenser.SlaveMachines.Select(x =>
                        {
                            switch (x.Model)
                            {
                                case "VisionEsPlus":
                                    {
                                        VisionEsPlusSettings settings = new VisionEsPlusSettings
                                        {
                                            PortNumber = (ushort)x.Port,
                                            Address = x.Address
                                        };

                                        ICommunicationChannel channel = null;

                                        if (kioskSettings.Dispenser.Mode != DeviceUseCase.Off)
                                        {
                                            switch (x.Protocol)
                                            {
                                                case Utils.Common.Enum.CommunicationProtocol.Serial:
                                                    channel = new SerialPortChannel(settings.PortNumber, settings.BaudRate, settings.Timeout, settings.CommandsSendDelay);
                                                    break;
                                                case Utils.Common.Enum.CommunicationProtocol.TCP:
                                                    channel = new TcpChannel(settings.Address, settings.PortNumber);
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }

                                        return new VisionEsPlusVendingMachine(x.Number.ToString(), new VisionEsPlus(channel, settings));
                                    }
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
