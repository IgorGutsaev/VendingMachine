using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions.Hardware;
using Filuet.Utils.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions
{
    /// <summary>
    /// Composite product dispenser
    /// </summary>
    /// <remarks>Can consist of any quantity of single dispensers</remarks>
    public interface ICompositeDispenser
    {
        event EventHandler<DispenseEventArgs> OnDispensing;

        event EventHandler<DeviceTestEventArgs> onTest;

        void Test();

        void Dispense(string address);

        void CheckChannel(string address);
    }
}
