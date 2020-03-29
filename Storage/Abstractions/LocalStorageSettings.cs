using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions
{
    public class LocalStorageSettings
    {
        public string DbFilepath { get; set; }
        public string CreateDbScriptPath { get; set; }
        public int MaxDatabaseSizeMB { get; set; } = 0; // 0 - unlimited
    }
}
