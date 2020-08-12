using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Common.Abstractions.Hardware
{
    /// <summary>
    /// Device state type
    /// </summary>
    [Flags]
    public enum DeviceStateSeverity
    {
        Normal = 0,
        /// <summary>
        /// Maintenance required, but can still work
        /// </summary>
        MaintenanceRequired = 2,
        /// <summary>
        /// Repair or urgent service required
        /// </summary>
        Inoperable = 1,
        /// <summary>
        /// The device is busy. Wait for some time
        /// </summary>
        NeedToWait = 3,
        /// <summary>
        /// Under maintenance
        /// </summary>
        MaintenanceService = 4
    }
}
