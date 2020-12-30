using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions.Hardware;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions
{
    /// <summary>
    /// Single dispensing unit
    /// </summary>
    public interface IDispenser
    {
        event EventHandler<DeviceTestEventArgs> onTest;

        string Id { get; }

        void Test();

        bool Dispense(DispenseAddress address, uint quantity);

        bool IsAddressAvailable(DispenseAddress address);

        /// <summary>
        /// Check addresses availability
        /// </summary>
        /// <returns></returns>
        IEnumerable<DispenseAddress> AreAddressesAvailable(IEnumerable<DispenseAddress> addresses);
    }
}
