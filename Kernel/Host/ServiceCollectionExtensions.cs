using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
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
using System.Linq;
using Filuet.Utils.Common.PosSettings;
using Filuet.ASC.Kiosk.OnBoard.SDK.Jofemar.VisionEsPlus;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Filuet.Utils.Abstractions.Communication;
using Filuet.Utils.Communication;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Core.Builders;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Tests.Entities;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Interfaces;
using System.Collections.Generic;
using Filuet.ASC.OnBoard.Payment.Abstractions.Interfaces;
using Filuet.Utils.Common.Business;
using Filuet.ASC.OnBoard.Payment.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Ecommerce.Service;
using Filuet.ASC.Kiosk.OnBoard.UVS.Core;

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

                    if (kioskSettings.Dispenser.Mode == OptionUseCase.Off)
                        return null;

                    return new CompositeDispenserBuilder()
                        .AddStrategy(sp.GetRequiredService<IDispensingStrategy>())
                        .AddDispensers(() =>
                            kioskSettings.Dispenser.SlaveMachines.Select(x =>
                            {
                                if (x.Model.Equals("VisionEsPlus", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    VisionEsPlusSettings settings = new VisionEsPlusSettings
                                    {
                                        PortNumber = (ushort)x.Port,
                                        Address = x.Address,
                                        IpAddress = x.IpAddress
                                    };

                                    ICommunicationChannel channel = null;

                                    if (kioskSettings.Dispenser.Mode != OptionUseCase.Off)
                                    {
                                        switch (x.Protocol)
                                        {
                                            case Utils.Common.Enum.CommunicationProtocol.Serial:
                                                channel = new SerialPortChannel(settings.PortNumber, settings.BaudRate, settings.Timeout, settings.CommandsSendDelay);
                                                break;
                                            case Utils.Common.Enum.CommunicationProtocol.TCP:
                                                channel = new TcpChannel(settings.IpAddress, settings.PortNumber);
                                                break;
                                            default:
                                                break;
                                        }
                                    }

                                    return new VisionEsPlusVendingMachine(x.Number.ToString(), new VisionEsPlus(channel, settings));
                                }
                                else
                                    throw new ArgumentException("Unknown dispenser model");
                            })
                    ).Build();
                })
                .AddLayout((sp) =>
                {
                    KioskSettings kioskSettings = sp.GetRequiredService<KioskSettings>();

                    if (kioskSettings.Dispenser.Mode == OptionUseCase.Off)
                        return null;

                    ILayoutBuilder layoutBuilder = new LayoutBuilder();

                    if (kioskSettings.Dispenser.SlaveMachines.Any(x => !x.Number.HasValue || x.Number == 0))
                        throw new ArgumentException("Machine number is mandatory");

                    kioskSettings.Dispenser.SlaveMachines.ToList().ForEach(x =>
                    {
                        if (x.Model.Equals("VisionEsPlus", StringComparison.InvariantCultureIgnoreCase))
                        {
                            // TODO: Refactor this stub
                            if (x.Number == 1)
                                layoutBuilder.AddMachine<VisionEspMachine, VisionEspTray, VisionEspBelt>(x.Number.Value)
                                    .AddTray(11)
                                        .AddBelt(2).CommitTray()
                                    .AddTray(18)
                                        .AddBelt(0).AddBelt(1).AddBelt(2).AddBelt(3).AddBelt(4).AddBelt(5).CommitTray().CommitMachine();

                            if (x.Number == 2)
                                layoutBuilder.AddMachine<VisionEspMachine, VisionEspTray, VisionEspBelt>(x.Number.Value)
                                    .AddTray(11)
                                        .AddBelt(0).AddBelt(1).AddBelt(2).AddBelt(3).AddBelt(4).CommitTray().CommitMachine();
                        }
                        else
                            throw new ArgumentException("Unknown dispenser model");

                    });

                    return layoutBuilder.Build();
                })
                .AddCashPayment((sp, cs) =>
                {
                    KioskSettings kioskSettings = sp.GetRequiredService<KioskSettings>();

                    IEnumerable<ICashDeviceAdapter> cashDevices = null;

                    switch (kioskSettings.Cashbox.Mode)
                    {
                        case OptionUseCase.Emulation:
                            cashDevices = new ICashDeviceAdapter[] {
                                new MockBillAcceptor(sp.GetRequiredService<ICurrencyConverter>(), (s) => {
                                    s.IssueIndex = 1;
                                    s.BaseCurrency = kioskSettings.BaseCurrency; // Stub
                                    s.BillsToReceive = new Money[] { Money.Create(100, CurrencyCode.USDollar), Money.Create(500, CurrencyCode.RussianRouble) }; // Stub
                                    s.BillsToGiveChange = new Money[] { Money.Create(50, CurrencyCode.RussianRouble), Money.Create(1, CurrencyCode.USDollar) }; // Stub
                                })
                           };
                            break;
                        case OptionUseCase.Off:
                            cashDevices = null;
                            break;
                        case OptionUseCase.On:
                            // ...
                            break;
                    }

                    cs.CashDevices = cashDevices;

                    return cs;
                })
                .AddEcommerce((sp, es) =>
                {
                    KioskSettings kioskSettings = sp.GetRequiredService<KioskSettings>();

                    foreach (var provider in kioskSettings.ECommerceSettings.PaymentProviders)
                    {
                        switch (provider.Source)
                        {
                            case PaymentSource.UVS:
                                if (kioskSettings.ECommerceSettings.Mode == OptionUseCase.Emulation)
                                    es.Add(new UvsMockEcommerceService(sp.GetRequiredService<ICurrencyConverter>(), (settings) => { settings.BaseCurrency = kioskSettings.BaseCurrency; }));
                                else if (kioskSettings.ECommerceSettings.Mode == OptionUseCase.On)
                                {
                                    // ...
                                }
                                break;
                            default:
                                throw new ArgumentException("Invalid ecommerce source");
                        }
                    }

                    return es;
                })
                .AddEventMediation((sp, broker) =>
                {
                    broker.AppendProducer(sp.GetRequiredService<IPaymentProvider>() as IEventProducer);
                    broker.AppendProducer(sp.GetRequiredService<ICashPaymentService>() as IEventProducer);
                    broker.AppendProducer(sp.GetRequiredService<ICompositeDispenser>() as IEventProducer);
                    broker.AppendProducer(sp.GetRequiredService<IStorageService>() as IEventProducer);
                    broker.AppendProducer(sp.GetRequiredService<IAttendant>() as IEventProducer);
                })
                .AddSingleton((sp) => new EventConsumer()
                    .AppendWriter<IPaymentProvider>(new EventWriter<IPaymentProvider>(sp.GetRequiredService<ILogger<IPaymentProvider>>()))
                    .AppendWriter<ICashPaymentService>(new EventWriter<ICashPaymentService>(sp.GetRequiredService<ILogger<ICashPaymentService>>()))
                    .AppendWriter<ICompositeDispenser>(new EventWriter<ICompositeDispenser>(sp.GetRequiredService<ILogger<ICompositeDispenser>>()))
                    .AppendWriter<IStorageService>(new EventWriter<IStorageService>(sp.GetRequiredService<ILogger<IStorageService>>()))
                    .AppendWriter<IAttendant>(new EventWriter<IAttendant>(sp.GetRequiredService<ILogger<IAttendant>>())));
        }
    }
}
