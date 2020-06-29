using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events
{
    public sealed class CashEventArgs: EventArgs
    {
        public EventItem Event { get; set; }

        public Money Money{ get; set; }
    }
}
