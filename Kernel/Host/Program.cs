using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Filuet.ASC.OnBoard.Dashboard.Host
{
    public class Program
    {
        public const string CONFIG_FILE = "appsettings.json";

        public static void Main(string[] args)
        {
            Console.WriteLine("The kiosk rises...");

            HostContext appContext = new FileInfo(CONFIG_FILE).ToConfiguration();


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
