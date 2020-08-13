using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Storage.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Tests
{
    public class BaseTest
    {
        const string CREATE_DB_SCRIPT_PATH = @"\..\..\..\cache.sql";
        const string DB_FILEPATH = @"\..\..\..\cache.db";
        const int MAX_DATABASE_SIZE = 1; //MB

        private IServiceProvider _provider;

        public IStorageService NewSignalService { get => _provider.GetService<IStorageService>(); }

        public BaseTest()
        {
            string rootDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.
                GetExecutingAssembly().Location);

            _provider = new ServiceCollection()
                .AddStorage()
                .AddCacheContext(s => {
                    s.CreateDbScriptPath = rootDir + CREATE_DB_SCRIPT_PATH;
                    s.DbFilepath = rootDir + DB_FILEPATH;
                    s.MaxDatabaseSizeMB = MAX_DATABASE_SIZE;
                }).BuildServiceProvider();
        }
    }
}
