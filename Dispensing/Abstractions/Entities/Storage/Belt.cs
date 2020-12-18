using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities
{
    public abstract class Belt : LayoutUnit, IBelt
    {
        public override string ToString() => $"Belt № {Number}";
    }
}
