using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions.Hardware;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.SDK.Jofemar.VisionEsPlus
{
    public class VisionEsPlusDispenser : IDispenser
    {
        public event EventHandler<DeviceTestEventArgs> onTest;
        private VisionEsPlus _machineAdapter;

        public VisionEsPlusDispenser(VisionEsPlus machineAdapter)
        {
            _machineAdapter = machineAdapter;
        }

        public void Test()
        {
            (DeviceStateSeverity severity, string message) testResult = _machineAdapter.Status();
            onTest?.Invoke(this, new DeviceTestEventArgs { Severity = testResult.severity, Message = testResult.message });
        }

        public void Dispense(TBAddress address)   
        {
            var t = _machineAdapter.Status(false);
            _machineAdapter.DispenseProduct(address.Tray, address.Belt);
            var t1 = _machineAdapter.Status(false);
        }

        public void IsAddressAvailable(TBAddress address)
        {
            _machineAdapter.IsBeltAvailable(address.Tray, address.Belt);
        }
    }
}
