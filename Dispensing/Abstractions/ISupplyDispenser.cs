using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions;
using Filuet.Utils.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions
{
    public class DispenseEventArgs : EventArgs
    {
        public string address { get; set; }

        public override string ToString()
            => $"{GetType().Name}({address})";
    }

    public interface ISupplyDispenser
    {
        event EventHandler<DispenseEventArgs> OnDispensing;

        void Dispense(string address);
    }
}
