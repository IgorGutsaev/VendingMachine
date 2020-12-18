using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Core.Builders
{
    internal sealed class LayoutBuilder<TTray, TBelt> : ILayoutBuilder<TTray, TBelt>
        where TTray : Tray, new()
        where TBelt : Belt, new()
    {
        private IList<IMachine> _machines = new List<IMachine>();

        public ILayoutBuilderMachine<TTray, TBelt> AddMachine<TMachine>(uint number)
            where TMachine : Machine, new()
        {
            IMachine machine = CreateMachine<TMachine>(number);
            return new LayoutBuilderMachine<TTray, TBelt>(this, machine);
        }

        private IMachine CreateMachine<TMachine>(uint number)
            where TMachine : Machine, new()
        {
            IMachine machine = _machines.SingleOrDefault(x => x.Number == number);
            if (machine == null)
            {
                machine = new TMachine();
                machine.SetNumber(number);
                _machines.Add(machine);
            }

            return machine;
        }

        public Layout Build(Func<ILayout, bool> validate = null)
        {
            Layout layout = new Layout();
            layout.AddMachines(_machines);
            
            return (validate == null || validate(layout)) ? layout : null;
        }
    }
}