using Filuet.Utils.Abstractions.Events;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Common.Platform
{
    public class EventWriter<T> : IEventWriter
    {
        public EventWriter(ILogger<T> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Push(EventItem item)
        {
            switch (item.Level)
            {
                case EventItem.EventLevel.Trace:
                    _logger.LogTrace(item.Exception, item.ErrorMessage);
                    break;
                case EventItem.EventLevel.Debug:
                    _logger.LogDebug(item.LayoutMessage);
                    break;
                case EventItem.EventLevel.Info:
                    _logger.LogInformation(item.LayoutMessage);
                    break;
                case EventItem.EventLevel.Warning:
                    _logger.LogWarning(item.LayoutMessage);
                    break;
                case EventItem.EventLevel.Error:
                    _logger.LogError(item.Exception, item.ErrorMessage);
                    break;
                case EventItem.EventLevel.Critical:
                    _logger.LogCritical(item.Exception, item.ErrorMessage);
                    break;
            }
        }

        private readonly ILogger<T> _logger;
    }
}
