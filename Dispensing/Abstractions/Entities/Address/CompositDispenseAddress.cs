using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities
{
    /// <summary>
    /// Issuance address
    /// </summary>
    public class CompositDispenseAddress : DispenseAddress
    {
        public string VendingMachineID { get; private set; }

        public static implicit operator String(CompositDispenseAddress address)
            => JsonConvert.SerializeObject(address);

        public static CompositDispenseAddress Create(string vendingMachineId, string address)
        {
            if (string.IsNullOrWhiteSpace(vendingMachineId))
                throw new ArgumentException("Vending machine identifier is mandatory");

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException("Address is mandatory");

            return new CompositDispenseAddress { VendingMachineID = vendingMachineId.Trim(), Address = address.Trim() };
        }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
