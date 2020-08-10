using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class PointsHeaders
    {
        public int Id { get; set; }
        public int GalvosId { get; set; }
        public double? Points { get; set; }
        public double? CenterPoints { get; set; }
        public int? DiscountIdentificator { get; set; }

        public virtual KvitoGalva Galvos { get; set; }
    }
}
