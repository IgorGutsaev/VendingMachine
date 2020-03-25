using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using System;
using System.Linq;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Core.Builders
{
    internal sealed class StoreBuilder<TMachine, TTray, TBelt> : IStoreBuilder<TMachine, TTray, TBelt>
        where TMachine : IStoreMachine<TTray, TBelt>, new()
        where TTray : IStoreTray<TBelt>, new()
        where TBelt : IStoreBelt, new()
    {
        private TMachine _machine = new TMachine();

        public IStoreBuilder<TMachine, TTray, TBelt> AddTray(uint number)
        {
            CreateTray(number);
            return this;
        }

        public IStoreBuilder<TMachine, TTray, TBelt> AddBelt(uint trayNumber, uint beltNumber)
        {
            CreateTray(trayNumber).AddBelt(beltNumber);
            return this;
        }

        private TTray CreateTray(uint number)
        {
            TTray tray = _machine.Trays.SingleOrDefault(x => x.Number == number);
            if (tray == null)
                tray = _machine.AddTray(number);

            return tray;
        }

        public TMachine Build(Func<TMachine, bool> validate = null) 
            => (validate == null || validate(_machine)) ? _machine : default(TMachine);
    }
}