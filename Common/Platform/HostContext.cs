using System;

namespace Filuet.ASC.Kiosk.OnBoard.Common.Platform
{
    public class HostContext
    {
        public StorageSettings Storage { get; set; }
    }

    public class StorageSettings
    {
        public string DbScriptFile { get; set; }
        public string DbFilePath { get; set; }
        public int MaxDatabaseSizeMB { get; set; } = 500; //MB

        public StorageSettings() { }
    }
}