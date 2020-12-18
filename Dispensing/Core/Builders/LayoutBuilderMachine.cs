using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using System;
using System.Linq;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Core.Builders
{
    internal sealed class LayoutBuilderMachine<TTray, TBelt> : ILayoutBuilderMachine<TTray, TBelt>
        where TTray : Tray, new()
        where TBelt : Belt, new()
    {
        private readonly ILayoutBuilder<TTray, TBelt> _layout;
        private readonly IMachine _activeMachine;

        public LayoutBuilderMachine(ILayoutBuilder<TTray, TBelt> layout, IMachine activeMachine)
        {
            if (layout == null)
                throw new ArgumentException("Layout is mandatory");

            if (activeMachine == null)
                throw new ArgumentException("Machine is mandatory");

            _layout = layout;
            _activeMachine = activeMachine;
        }

        public ILayoutBuilderTray<TTray, TBelt> AddTray(uint number)
        {
            ITray tray = CreateTray(number);
            return new LayoutBuilderTray<TTray, TBelt>(this, tray);
        }

        private ITray CreateTray(uint number)
        {
            ITray tray = _activeMachine.Trays.SingleOrDefault(x => x.Number == number);
            if (tray == null)
                tray = _activeMachine.AddTray<TTray>(number);

            return tray;
        }

        public ILayoutBuilder<TTray, TBelt> CommitMachine()
            => _layout;
    }
}