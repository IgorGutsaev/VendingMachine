using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions.Hardware;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Core
{
    internal class CompositeDispenser : ICompositeDispenser
    {
        public event EventHandler<DispenseEventArgs> OnDispensing;
        public event EventHandler<DeviceTestEventArgs> OnTest;
        public event EventHandler<DispenseFailEventArgs> OnFailed;

        public CompositeDispenser(IEnumerable<IDispenser> dispensers)
        {
            _dispensers = dispensers;
        }

        public void CheckChannel(CompositIssueAddress address)
        {
            throw new NotImplementedException();
        }

        public void Dispense(CompositIssueAddress address)
        {
            OnDispensing?.Invoke(this, new DispenseEventArgs { address = address });

            IDispenser _dispenser = _dispensers.SingleOrDefault(x => x.Id == address.VendingMachineID);

            if (_dispenser == null)
                OnFailed?.Invoke(this, new DispenseFailEventArgs { address = address, message = "Unable to detect the machine" });

            _dispenser.Dispense(address);
        }

        public void Test()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<IDispenser> _dispensers;
    }
}