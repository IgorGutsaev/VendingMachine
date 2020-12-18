using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities
{
    /// <summary>
    /// Issuance address
    /// </summary>
    public abstract class IssueAddress
    {
        public string Address { get; protected set; }

        public override string ToString() => Address;
    }
}
