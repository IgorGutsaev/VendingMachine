using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities
{
    public class TBAddress
    {
        public int Tray { get; set; }
        public int Belt { get; set; }

        public override string ToString() => $"T:{Tray}/B:{Belt}";
    }

    public class MTBAddress : TBAddress
    {
        public int Machine { get; set; }

        public override string ToString() => $"M:{Machine}/{base.ToString()}";
    }
}
