using Filuet.Utils.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions
{
    public sealed class StopCashEventArgs:EventArgs
    {
        public string Description { get; set; }

        public EventItem Event { get; set; }
    }
}
