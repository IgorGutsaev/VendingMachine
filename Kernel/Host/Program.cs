using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Kernel.Core;
using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Storage.Core;
using Filuet.Utils.Abstractions.Event;
using Filuet.Utils.Abstractions.Events;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
                IStorageService s2 = host.Services.GetRequiredService<IStorageService>();

                ISupplyDispenser s1 = host.Services.GetRequiredService<ISupplyDispenser>();
                var t = s2.Get(x => true);

                s1.OnDispensing += S1_OnDispensing;
                s1.OnDispensing -= S1_OnDispensing;
                s1.Dispense("foo");
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

                    services.AddHardware();

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
