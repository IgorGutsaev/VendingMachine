﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.SDK.Jofemar.VisionEsPlus
{
    public class VisionEsPlusSettings
    {
        /// <summary>
        /// TCP: Ip address; Serial: 0x01 by default (all machines have 0x01 address cause we're separating them by serial ports)
        /// </summary>
        public string Address { get; set; } //= 0x01;
        public UInt16 PortNumber { get; set; }
        public UInt16 BaudRate { get; set; } = 9600;
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(2);
        public TimeSpan CommandsSendDelay { get; set; } = TimeSpan.FromSeconds(0.2);
        public VisionEsPlusLightEmitterSettings LightSettings { get; set; } = new VisionEsPlusLightEmitterSettings();
    }
}
