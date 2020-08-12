using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions.Hardware;
using Filuet.ASC.Kiosk.OnBoard.Common.Platform;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.Utils.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Core
{
    public class CompositeDispenserBuilder
    {
        public CompositeDispenserBuilder AddDispensers(Func<IEnumerable<IDispenser>> getDispensers)
        {
            _dispensers = getDispensers();
            return this;
        }

        public ICompositeDispenser Build()
        {
            return new CompositeDispenser(_dispensers);
        }

        private IEnumerable<IDispenser> _dispensers;
    }
}
