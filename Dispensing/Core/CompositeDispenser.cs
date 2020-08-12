using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions.Hardware;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.Utils.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Core
{
    internal class CompositeDispenser : ICompositeDispenser
    {
        public event EventHandler<DispenseEventArgs> OnDispensing;
        public event EventHandler<DeviceTestEventArgs> onTest;

        public CompositeDispenser(IEnumerable<IDispenser> dispensers)
        {
            _dispensers = dispensers;
        }

        public void CheckChannel(string address)
        {
            throw new NotImplementedException();
        }

        public void Dispense(string address)
        {
            OnDispensing?.Invoke(this, new DispenseEventArgs { address = "Hello world" });
        }

        public void Test()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<IDispenser> _dispensers;
    }
}
