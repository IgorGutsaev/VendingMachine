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

        public bool Dispense(DispenseAddress address, uint quantity)   
        {
            var t = _machineAdapter.Status(false);
            bool result = _machineAdapter.DispenseProduct(address, quantity);
            var t1 = _machineAdapter.Status(false);

            return result;
        }

        public bool IsAddressAvailable(DispenseAddress address)
            => _machineAdapter.IsBeltAvailable(address);

        public IEnumerable<DispenseAddress> AreAddressesAvailable(IEnumerable<DispenseAddress> addresses)
        {
            foreach (var a in addresses)
                if (IsAddressAvailable(a))
                    yield return a;
        }
    }
}
