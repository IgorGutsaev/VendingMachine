using Filuet.Utils.Abstractions.Events;
using Filuet.Utils.Common.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Cashless.Abstractions.Events
{
    public class CardEventArgs : EventArgs
    {
        public EventItem Event{ get; set; }

        public Money Money { get; set; }
    }
}
