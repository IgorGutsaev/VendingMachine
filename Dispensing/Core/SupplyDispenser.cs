using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.Utils.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Core
{
    public class SupplyDispenser : ISupplyDispenser
    {
        public event EventHandler<EventItem> OnEvent;

        public void Dispense()
        {
            OnEvent?.Invoke(this, EventItem.Info("Hello world"));
        }

        public void Subscribe(Action<object, EventItem> onEvent)
        {
            OnEvent += (sender, ev) => onEvent(sender, ev);
        }
    }
}
