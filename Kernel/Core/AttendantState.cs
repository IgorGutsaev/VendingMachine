using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Filuet.ASC.OnBoard.Kernel.Core
{
    public enum AttendantState
    {
        [Description("Idle")]
        Idle,
        [Description("Busy")]
        Busy,
        [Description("Error")]
        Error
    }
}
