using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using System;
using System.Linq;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Core.Builders
{
    internal sealed class LayoutBuilderTray<TTray, TBelt> : ILayoutBuilderTray<TTray, TBelt>
        where TTray : Tray, new()
        where TBelt : Belt, new()
    {
        private readonly LayoutBuilderMachine<TTray, TBelt> _layoutMachine;
        private readonly ITray _activeTray;

        public LayoutBuilderTray(LayoutBuilderMachine<TTray, TBelt> layoutMachine, ITray activeTray)
        {
            if (layoutMachine == null)
                throw new ArgumentException("Layout is mandatory");

            if (activeTray == null)
                throw new ArgumentException("Tray is mandatory");

            _layoutMachine = layoutMachine;
            _activeTray = activeTray;
        }

        public ILayoutBuilderTray<TTray, TBelt> AddBelt(uint number)
        {
            IBelt belt = CreateBelt(number);
            return this; 
        }

        private IBelt CreateBelt(uint number)
        {
            IBelt belt = _activeTray.Belts.SingleOrDefault(x => x.Number == number);
            if (belt == null)
                belt = _activeTray.AddBelt<TBelt>(number);

            return belt;
        }

        public ILayoutBuilderMachine<TTray, TBelt> CommitTray()
            => _layoutMachine;
    }
}