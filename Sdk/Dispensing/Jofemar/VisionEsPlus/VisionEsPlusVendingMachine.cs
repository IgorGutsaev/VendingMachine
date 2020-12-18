using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions.Hardware;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.SDK.Jofemar.VisionEsPlus
{
    public class VisionEsPlusVendingMachine : IDispenser
    {
        public event EventHandler<DeviceTestEventArgs> onTest;
        private VisionEsPlus _machineAdapter;

        public string Id { get; private set; }

        public VisionEsPlusVendingMachine(string id, VisionEsPlus machineAdapter)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException();

            _machineAdapter = machineAdapter;
            Id = id;
        }

        public void Test()
        {
            (DeviceStateSeverity severity, string message) testResult = _machineAdapter.Status();
            onTest?.Invoke(this, new DeviceTestEventArgs { Severity = testResult.severity, Message = testResult.message });
        }

        public void Dispense(IssueAddress address)   
        {
            var t = _machineAdapter.Status(false);

            _machineAdapter.DispenseProduct(address);
            var t1 = _machineAdapter.Status(false);
        }

        public bool IsAddressAvailable(IssueAddress address)
            => _machineAdapter.IsBeltAvailable(address);

        public IEnumerable<IssueAddress> AreAddressesAvailable(IEnumerable<IssueAddress> addresses)
        {
            foreach (var a in addresses)
                if (IsAddressAvailable(a))
                    yield return a;
        }
    }
}
