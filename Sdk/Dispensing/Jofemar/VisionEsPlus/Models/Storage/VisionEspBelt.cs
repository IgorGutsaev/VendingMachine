using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using Newtonsoft.Json;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Tests.Entities
{
    public class VisionEspBelt : Belt {
        public override string Address => JsonConvert.SerializeObject(new { T = Tray.Number, B = Number });
    }
}
