using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Common.Platform
{
    public static class ApplicationConfiguration
    {
        /// <summary>
        /// Create configuration root from json file
        /// </summary>
        /// <param name="appConfigFile"></param>
        /// <returns></returns>
        public static HostContext ToConfiguration(this FileInfo appConfigFile)
        {
            if (!appConfigFile.Exists)
                throw new FileNotFoundException($"Missing config file: '{appConfigFile.Name}'");

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(appConfigFile.FullName).Build();

            return config.GetSection("Context").Get<HostContext>();
        }
    }
}
