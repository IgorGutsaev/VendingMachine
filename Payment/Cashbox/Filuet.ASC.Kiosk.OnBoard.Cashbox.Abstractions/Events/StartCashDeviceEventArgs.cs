using Filuet.Utils.Abstractions.Events;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions
{
    public sealed class StartCashDeviceEventArgs : EventArgs
    {
        public string Description { get; set; }

        public EventItem Event { get; set; }
    }
}
