using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities
{
    /// <summary>
    /// Issuance address
    /// </summary>
    public class CompositIssueAddress : IssueAddress
    {
        public string VendingMachineID { get; private set; }

        public static implicit operator String(CompositIssueAddress address)
            => JsonConvert.SerializeObject(address);

        public static CompositIssueAddress Create(string vendingMachineId, string address)
        {
            if (string.IsNullOrWhiteSpace(vendingMachineId))
                throw new ArgumentException("Vending machine identifier is mandatory");

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address is mandatory");

            return new CompositIssueAddress { VendingMachineID = vendingMachineId.Trim(), Address = address.Trim() };
        }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
