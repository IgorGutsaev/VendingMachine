using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using Filuet.ASC.Kiosk.OnBoard.Kernel.Core;
using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Storage.Core;
using Filuet.ASC.OnBoard.Kernel.Core;
using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Abstractions.Platform;
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

            // POC
            Task.Run(() =>
            {
                IAttendant att = host.Services.GetRequiredService<IAttendant>();

                att.StartOrder(b => { });

                IStorageService s2 = host.Services.GetRequiredService<IStorageService>();

                ICompositeDispenser s1 = host.Services.GetRequiredService<ICompositeDispenser>();
                var t = s2.Get(x => true);

                s1.OnDispensing += S1_OnDispensing;
                s1.OnDispensing -= S1_OnDispensing;
                
                s1.Dispense(CompositIssueAddress.Create(vendingMachineId: "1", address: "1/13/0"));
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
                        .AddSingleton((sp) => new KioskSettings {
                            Dispenser = new DispensingSettings {  SlaveMachines = new VendingMachine[] { 
                                new VendingMachine { Number = 1, Port = 9 },
                                new VendingMachine { Number = 2, Port = 10 }
                            } }
                        })
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
