using Filuet.Utils.Extensions.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.SlipAbstractions
{
    public enum SlipKind
    {
        [Code("Standard")]
        Standard = 0x01,
        [Code("Crash")]
        Crash,
        [Code("Test")]
        Test
    }
}
