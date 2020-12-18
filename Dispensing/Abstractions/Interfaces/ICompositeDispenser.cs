using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions.Hardware;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions
{
    /// <summary>
    /// Composite product dispenser
    /// </summary>
    /// <remarks>Can consist of any quantity of single dispensers</remarks>
    public interface ICompositeDispenser
    {
        event EventHandler<DispenseEventArgs> OnDispensing;

        event EventHandler<DeviceTestEventArgs> OnTest;

        void Test();

        //IEnumerable<CompositIssueAddress> A

        void Dispense(CompositIssueAddress address);

        void CheckChannel(CompositIssueAddress address);
    }
}
