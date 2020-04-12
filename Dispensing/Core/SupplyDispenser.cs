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
        public event EventHandler<DispenseEventArgs> OnDispensing;

        public void Dispense(string address)
        {
            OnDispensing?.Invoke(this, new DispenseEventArgs { address = "Hello world" });
        }
    }
}
