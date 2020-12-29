using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Kernel.Core;
using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions.Enums;
using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Storage.Core;
using Filuet.ASC.OnBoard.Kernel.Core;
using Filuet.ASC.OnBoard.Payment.Abstractions;
using Filuet.ASC.OnBoard.Payment.Core;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Abstractions.Platform;
using Filuet.Utils.Common.Business;
using Filuet.Utils.Common.PosSettings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Filuet.ASC.OnBoard.Kernel.HostApp
{
    public class Program
    {
        public const string CONFIG_FILE = "appsettings.json";

        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            IEventBroker broker = host.Services.GetRequiredService<IEventBroker>(); // initialize evenk broker
            // instantiate mediators
            OrderingMediator mediator = host.Services.GetRequiredService<OrderingMediator>(); 
            PaymentMediator paymentMediator = host.Services.GetRequiredService<PaymentMediator>();

            // POC
            Task.Run(() =>
            {
                Thread.Sleep(1500);

                IAttendant att = host.Services.GetRequiredService<IAttendant>();

                att.StartOrder(b => b.WithHeader("TST123456", "9262147116")
                    .WithObtainingMethod(GoodsObtainingMethod.Warehouse)
                    .WithItems(OrderLine.Create("0141", Money.Create(10.0m, CurrencyCode.Euro)))
                    .WithTotalAmount(Money.Create(10.0m, CurrencyCode.Euro)));

                IPaymentProvider paymentProvider = host.Services.GetRequiredService<IPaymentProvider>();
                ICashPaymentService cashPaymentService = host.Services.GetRequiredService<ICashPaymentService>();

                paymentProvider.Collect(Money.Create(7775m, CurrencyCode.RussianRouble), (p) => { });
                cashPaymentService.CashDevices.First().Start();

                att.CompleteOrder();

                return;

                IStorageService s2 = host.Services.GetRequiredService<IStorageService>();

                ICompositeDispenser dispenser = host.Services.GetRequiredService<ICompositeDispenser>();

                ILayout layout = host.Services.GetRequiredService<ILayout>();
                if (layout == null)
                {
                    var t = s2.Get(x => true);
                }

                dispenser.OnDispensing += S1_OnDispensing;

                dispenser.Dispense(CompositIssueAddress.Create(vendingMachineId: layout.Machines.First().Number.ToString(), layout.Machines.First().Trays.First().Belts.First().Address));

                dispenser.OnDispensing -= S1_OnDispensing;
            });

            host.Run();
        }

        private static void S1_OnDispensing(object sender, EventArgs e)
        {
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices((services) =>
                {
                    HostContext appContext = new FileInfo(CONFIG_FILE).ToConfiguration();

                    services
                        .AddSingleton((sp) => new KioskSettings
                        {
                            Dispenser = new DispensingSettings
                            {
                                Mode = DeviceUseCase.On,
                                SlaveMachines = new VendingMachine[] {
                                    new VendingMachine { Number = 1, Address = "0x01", Model = "VisionEsPlus", Protocol = Utils.Common.Enum.CommunicationProtocol.TCP,
                                        IpAddress = "172.16.7.103",
                                        Port = 5000},
                                    new VendingMachine { Number = 2, Address = "0x02", Model = "visionEsPlus", Protocol = Utils.Common.Enum.CommunicationProtocol.TCP,
                                        IpAddress = "172.16.7.103",
                                        Port = 5000 }
                                }
                            },
                            Cashbox = new CashboxSettings { Mode = DeviceUseCase.Emulation }
                        })
                        .AddPaymentProvider()
                        .AddAttendant()
                        .AddHardware();

                    services.AddStorage()
                        .AddCacheContext(settings =>
                        {
                            string rootDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                            settings.CreateDbScriptPath = rootDir + @"\" + appContext.Storage.DbScriptFile;
                            settings.DbFilepath = rootDir + @"\" + appContext.Storage.DbFilePath;
                            settings.MaxDatabaseSizeMB = appContext.Storage.MaxDatabaseSizeMB;
                        });
                });
    }
}
