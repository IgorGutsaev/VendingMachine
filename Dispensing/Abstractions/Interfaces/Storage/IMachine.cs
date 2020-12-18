using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces
{
    public interface IMachine : ILayoutUnit
    {
        IEnumerable<ITray> Trays { get; }

        ITray AddTray<TTray>(uint number)
            where TTray : Tray, new();
    }
}
