using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class PointsItems
    {
        public int Id { get; set; }
        public int KvitoEiluteId { get; set; }
        public double? Points { get; set; }
        public int? DiscountIdentificator { get; set; }

        public virtual KvitoEilute KvitoEilute { get; set; }
    }
}
