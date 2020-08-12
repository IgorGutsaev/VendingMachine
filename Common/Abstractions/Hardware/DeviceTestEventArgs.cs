using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Common.Abstractions.Hardware
{
    public class DeviceTestEventArgs : EventArgs
    {
        public DeviceStateSeverity Severity { get; set; } = DeviceStateSeverity.Normal;
        public string Message { get; set; }
    }
}
