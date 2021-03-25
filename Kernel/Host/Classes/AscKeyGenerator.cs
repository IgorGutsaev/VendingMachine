using Serilog.Events;
using Serilog.Sinks.AzureTableStorage.KeyGenerator;
using System;

namespace Filuet.ASC.OnBoard.Kernel.HostApp.Classes
{
    public class AscKeyGenerator : IKeyGenerator
    {
        string IKeyGenerator.GeneratePartitionKey(LogEvent logEvent)
        {
            return (DateTime.MaxValue.Ticks - logEvent.Timestamp.Ticks).ToString().Substring(0, 9);
        }

        string IKeyGenerator.GenerateRowKey(LogEvent logEvent, string suffix)
        {
            return (DateTime.MaxValue.Ticks - logEvent.Timestamp.Ticks).ToString() + "." + Guid.NewGuid().ToString();
        }
    }
}