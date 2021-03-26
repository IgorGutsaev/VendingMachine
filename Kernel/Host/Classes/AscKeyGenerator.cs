using Serilog.Events;
using Serilog.Sinks.AzureTableStorage.KeyGenerator;
using System;

namespace Filuet.ASC.OnBoard.Kernel.HostApp.Classes
{
    public class AscKeyGenerator : IKeyGenerator
    {
        private readonly string _partitionId;

        public AscKeyGenerator(string patritionId)
        {
            _partitionId = patritionId;
        }

        string IKeyGenerator.GeneratePartitionKey(LogEvent logEvent) => _partitionId + $"_{DateTime.Now:yyyyMMdd}";
        // return (DateTime.MaxValue.Ticks - logEvent.Timestamp.Ticks).ToString().Substring(0, 9);

        string IKeyGenerator.GenerateRowKey(LogEvent logEvent, string suffix)
        {
            return (DateTime.MaxValue.Ticks - logEvent.Timestamp.Ticks).ToString() + "." + Guid.NewGuid().ToString();
        }
    }
}