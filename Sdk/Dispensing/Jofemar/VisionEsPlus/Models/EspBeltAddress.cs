using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using Newtonsoft.Json;

namespace Filuet.ASC.Kiosk.OnBoard.SDK.Jofemar.VisionEsPlus.Models
{
    public class EspBeltAddress
    {
        public int Tray { get; private set; }

        public int Belt { get; private set; }

        public static implicit operator EspBeltAddress(DispenseAddress address)
            => JsonConvert.DeserializeObject<EspBeltAddress>(address.Address);
    }
}