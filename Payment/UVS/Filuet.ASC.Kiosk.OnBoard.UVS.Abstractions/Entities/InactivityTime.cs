using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class InactivityTime
    {
        public int Id { get; set; }
        public int KvitoEiluteId { get; set; }
        public double? Duration { get; set; }

        public virtual KvitoEilute KvitoEilute { get; set; }
    }
}
