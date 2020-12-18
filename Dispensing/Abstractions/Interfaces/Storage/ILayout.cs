using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces
{
    public interface ILayout
    {
        IEnumerable<IMachine> Machines { get; }

        IMachine AddMachine<TMachine>(uint number)
            where TMachine : Machine, new();

        ILayout AddMachines(IEnumerable<IMachine> machines);
    }
}
