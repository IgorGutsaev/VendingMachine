using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities
{
    /// <summary>
    /// Dispensing address
    /// </summary>
    public abstract class DispenseAddress
    {
        public string Address { get; protected set; }

        public override string ToString() => Address;
    }
}
