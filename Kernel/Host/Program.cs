using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Catalog.Service;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Kernel.Core;
using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions.Enums;
using Filuet.ASC.Kiosk.OnBoard.SlipService;
using Filuet.ASC.Kiosk.OnBoard.SlipService.SlipFabrics;
using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Storage.Core;
using Filuet.ASC.OnBoard.Kernel.Core;
using Filuet.ASC.OnBoard.Payment.Abstractions;
using Filuet.ASC.OnBoard.Payment.Core;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Abstractions.Platform;
using Filuet.Utils.Common.Business;
using Filuet.Utils.Common.PosSettings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Filuet.Utils.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Runtime.InteropServices;

namespace Filuet.ASC.OnBoard.Kernel.HostApp
{
    public class Program
    {
        public const string CONFIG_FILE = "appsettings.json";

        static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                Log.Logger.Information("OnBoard hostapp closed");
                Thread.Sleep(1000 * (_logBatchHoldPeriodSec + 1)); // It should me more than Serilog AzureTableStorage period
            }
            return false;
        }

        public static void Main(string[] args)
        {
            handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(handler, true);

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

                att.StartOrder(b => b.WithHeader("TST123456", "9262147116", "IVG", Locale.Latvia, Lang.Lv)
                    .WithObtainingMethod(GoodsObtainingMethod.Warehouse)
                    .WithItems(OrderLine.Create("0141", Money.Create(10.0m, CurrencyCode.Euro)))
                    .WithTotalValues(Money.Create(10.0m, CurrencyCode.Euro), 15.95m)
                    .WithExtraData("Kiosk", "LRK0123456")
                    .WithExtraData("SelectedMonth", "february 2021"));

                IPaymentProvider paymentProvider = host.Services.GetRequiredService<IPaymentProvider>();
                ICashPaymentService cashPaymentService = host.Services.GetRequiredService<ICashPaymentService>(); // пользователь выбрал оплату кешем (не payment provider так решил, а пользователь)

                paymentProvider.Collect(PaymentSource.UVS, att.Order, (p) => { });


                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(10000);
                    att.CompleteOrder();
                });

                /*IStorageService s2 = host.Services.GetRequiredService<IStorageService>();

                ICompositeDispenser dispenser = host.Services.GetRequiredService<ICompositeDispenser>();

                ILayout layout = host.Services.GetRequiredService<ILayout>();
                if (layout == null)
                {
                    var t = s2.Get(x => true);
                }

                dispenser.OnDispensing += S1_OnDispensing;

                dispenser.Dispense(CompositDispenseAddress.Create(vendingMachineId: layout.Machines.First().Number.ToString(), layout.Machines.First().Trays.First().Belts.First().Address));

                dispenser.OnDispensing -= S1_OnDispensing;*/
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
                    //webBuilder.UseConfiguration(new ConfigurationBuilder()
                    //.AddCommandLine(args)
                    //.Build());
                })
#if DEBUG
                            .UseEnvironment("Development")
#elif !DEBUG
                            .UseEnvironment("Production")
#endif
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(AppContext.BaseDirectory)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true)
                        .AddEnvironmentVariables();
                })
                .ConfigureLogging((context, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConfiguration(context.Configuration.GetSection("Logging"));

                    logging.AddSerilog(Log.Logger);
#if DEBUG
                    logging.SetMinimumLevel(LogLevel.None);
                    logging.AddConsole();
                    logging.AddDebug();
#elif !DEBUG
                    logging.SetMinimumLevel(LogLevel.Warning);
                    logging.AddAzureWebAppDiagnostics();
#endif
                })
                .ConfigureServices((services) =>
                {
                    HostContext appContext = new FileInfo(CONFIG_FILE).ToConfiguration();
                    services
                        .AddSingleton((sp) => new KioskSettings
                        {
                            BaseCurrency = EnumHelper.GetValueFromCode<CurrencyCode>(appContext.Payment.BaseCurrency),
                            Dispenser = new DispensingSettings
                            {
                                Mode = OptionUseCase.On,
                                SlaveMachines = new VendingMachine[] {
                                            new VendingMachine { Number = 1, Address = "0x01", Model = "VisionEsPlus", Protocol = Utils.Common.Enum.CommunicationProtocol.TCP,
                                                IpAddress = "172.16.7.103",
                                                Port = 5000},
                                            new VendingMachine { Number = 2, Address = "0x02", Model = "visionEsPlus", Protocol = Utils.Common.Enum.CommunicationProtocol.TCP,
                                                IpAddress = "172.16.7.103",
                                                Port = 5000 }
                                }
                            },
                            Cashbox = new CashboxSettings { Mode = OptionUseCase.Emulation },
                            ECommerceSettings = new EcommerceSettings { Mode = OptionUseCase.Emulation, PaymentProviders = new[] { new UvsEcommerceSettings { } } }
                })
                .AddPaymentProvider()
                .AddAttendant()
                .AddCatalog()
                .AddSlipService((setup) =>
                {
                            // Stub
                            setup.SlipComponentsRepositoryPath = @"D:\Repos\Filuet.ASC.Kiosk.OnBoard\Slip\SlipComponents";
                    setup.SlipImageStorage = @"D:\SlipImages";
                })
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

        static ConsoleEventDelegate handler;   // Keeps it from getting garbage collected
                                               // Pinvoke
        private delegate bool ConsoleEventDelegate(int eventType);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);

        public static int _logBatchHoldPeriodSec = 0;
    }
}
