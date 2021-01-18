using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Core
{
    public class CompositeDispenserBuilder
    {
        public CompositeDispenserBuilder AddStrategy(IDispensingStrategy strategy)
        {
            _strategy = strategy;
            return this;
        }

        public CompositeDispenserBuilder AddDispensers(Func<IEnumerable<IDispenser>> getDispensers)
        {
            _dispensers = getDispensers();
            return this;
        }

        public ICompositeDispenser Build()
        {
            return new CompositeDispenser(_dispensers, _strategy);
        }

        private IEnumerable<IDispenser> _dispensers;
        private IDispensingStrategy _strategy;
    }
}
