using Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Storage.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Tests
{
    public class BaseTest
    {
        const string CREATE_DB_SCRIPT_PATH = @"\..\..\..\cache.sql";
        const string DB_FILEPATH = @"\..\..\..\cache.db";
        const int MAX_DATABASE_SIZE = 1; //MB

        private IServiceProvider _provider;

        public IKioskStorageService NewSignalService { get => _provider.GetService<IKioskStorageService>(); }

        public BaseTest()
        {
            string rootDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.
                GetExecutingAssembly().Location);

            _provider = new ServiceCollection()
                .AddStorageService()
                .AddCacheContext(s => {
                    s.CreateDbScriptPath = rootDir + CREATE_DB_SCRIPT_PATH;
                    s.DbFilepath = rootDir + DB_FILEPATH;
                    s.MaxDatabaseSizeMB = MAX_DATABASE_SIZE;
                }).BuildServiceProvider();
        }
    }
}
