using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.SDK.Jofemar.VisionEsPlus.Models
{
    public class EspBeltAddress
    {
        public int Tray { get; private set; }

        public int Belt { get; private set; }

        public static implicit operator EspBeltAddress(IssueAddress address)
            => JsonConvert.DeserializeObject<EspBeltAddress>(address.Address);
    }
}
