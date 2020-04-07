using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.Utils.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Core
{
    internal class SupplyDispenser : ISupplyDispenser
    {
        public void Dispense(string address)
        {
           // OnEvent?.Invoke(this, EventItem.Info("Hello world"));
        }

        public void Subscribe(Action<object, EventItem> onEvent)
        {
           // OnEvent += (sender, ev) => onEvent(sender, ev);
        }
    }
}
