using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Common.Abstractions.Hardware
{
    public enum DoorState : byte
    {
        Unknown = 0,
        DoorOpen = 0x4F,
        DoorClosed = 0x43
    }
}
