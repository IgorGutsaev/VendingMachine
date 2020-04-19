using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions
{
    public class StorageSettings
    {
        public string DbScriptFile { get; set; }
        public string DbFilePath { get; set; }
        public int MaxDatabaseSizeMB { get; set; } = 500; //MB

        public StorageSettings() { }
    }
}
