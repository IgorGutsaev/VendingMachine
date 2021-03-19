using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Filuet.ASC.Kiosk.OnBoard.Kernel.Core
{
    public static class ApplicationConfiguration
    {

        private static IConfigurationRoot  GetConfig(FileInfo appConfigFile)
        {
            if (!appConfigFile.Exists)
                throw new FileNotFoundException($"Missing config file: '{appConfigFile.Name}'");

            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(appConfigFile.FullName).Build();
        }

        /// <summary>
        /// Create configuration root from json file
        /// </summary>
        /// <param name="appConfigFile"></param>
        /// <returns></returns>
        public static HostContext ToConfiguration(this FileInfo appConfigFile)
        {
            var config = GetConfig(appConfigFile);

            return config.GetSection("Context").Get<HostContext>();
        }

        public static LogSettings FromConfiguration(this FileInfo appConfigFile)
        {
            var config = GetConfig(appConfigFile);

            var serilog = config.GetSection("Serilog").Get<SerilogSelection>();

            return new LogSettings().FromArgs(serilog.WriteTo.First().Args);
        }
    }
}
