using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.SDK.Jofemar.VisionEsPlus
{
    public class VisionEsPlusLightEmitterSettings
    {
        public bool LightIsOn { get; set; } = false;
        public TimeSpan BlinkingPeriod { get; set; } = TimeSpan.FromSeconds(0.5);
    }
}
