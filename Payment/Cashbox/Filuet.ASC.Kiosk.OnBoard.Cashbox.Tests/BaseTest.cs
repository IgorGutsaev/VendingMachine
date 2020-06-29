using Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Cashbox.Core;
using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Storage.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Tests
{
    public class BaseTest
    {
        const string CREATE_DB_SCRIPT_PATH = @"\cache.sql";
        const string DB_FILEPATH = @"\cache.db";
        const int MAX_DATABASE_SIZE = 1; //MB

        protected ICashPaymentService cashPaymentService;

        public BaseTest()
        {
            cashPaymentService = new CashPaymentService();

            string rootDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.
                GetExecutingAssembly().Location);

            var provider = new ServiceCollection()
                .AddStorage()
                .AddCacheContext(s => {
                    s.CreateDbScriptPath = rootDir + CREATE_DB_SCRIPT_PATH;
                    s.DbFilepath = rootDir + DB_FILEPATH;
                    s.MaxDatabaseSizeMB = MAX_DATABASE_SIZE;
                }).BuildServiceProvider();

            cashPaymentService.AddStorage(provider.GetService<IStorageService>());
        }
    }
}
