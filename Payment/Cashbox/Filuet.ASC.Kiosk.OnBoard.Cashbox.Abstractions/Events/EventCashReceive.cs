using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions.Events
{
    public sealed class EventCashReceive
    {
        public EventItem Event { get; set; }

        public Money Money{ get; set; }
    }
}
