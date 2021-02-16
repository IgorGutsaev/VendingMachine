using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions.Hardware;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities.Dispensing;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Ordering.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Core
{
    internal class CompositeDispenser : ICompositeDispenser
    {
        public CompositeDispenser(IEnumerable<IDispenser> dispensers, IDispensingStrategy strategy)
        {
            _dispensers = dispensers;
            _strategy = strategy;
        }

        public void CheckChannel(CompositDispenseAddress address)
        {
            throw new NotImplementedException();
        }

        public void Dispense(IEnumerable<OrderItem> items)
        {
            IEnumerable<DispenseCommand> dispensingChain = _strategy.BuildDispensingChain(items);

            foreach (DispenseCommand command in dispensingChain)
            {
                IDispenser _dispenser = _dispensers.SingleOrDefault(x => x.Id == command.Address.VendingMachineID);

                if (_dispenser == null)
                    OnFailed?.Invoke(this, new DispenseFailEventArgs { address = command.Address.Address, message = "Unable to detect the machine" });

                if (_dispenser.Dispense(command.Address, command.Quantity))
                    OnDispensing?.Invoke(this, new DispenseEventArgs { address = command.Address.Address });
            }
        }

        public void Test()
        {
            throw new NotImplementedException();
        }

        public event EventHandler<DispenseEventArgs> OnDispensing;

        public event EventHandler<DeviceTestEventArgs> OnTest;

        public event EventHandler<DispenseFailEventArgs> OnFailed;

        private IEnumerable<IDispenser> _dispensers;

        private IDispensingStrategy _strategy;
    }
}