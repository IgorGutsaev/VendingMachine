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

        void Dispense(IssueAddress address);

        bool IsAddressAvailable(IssueAddress address);

        /// <summary>
        /// Check addresses availability
        /// </summary>
        /// <returns></returns>
        IEnumerable<IssueAddress> AreAddressesAvailable(IEnumerable<IssueAddress> addresses);
    }
}
