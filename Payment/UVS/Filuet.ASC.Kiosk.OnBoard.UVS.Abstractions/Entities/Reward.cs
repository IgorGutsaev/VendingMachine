using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Reward
    {
        public int Id { get; set; }
        public int GalvosId { get; set; }
        public int? DiscountIdentificator { get; set; }
        public string RewardIdentificator { get; set; }
        public string CouponBarcode { get; set; }
        public bool? IsGsm { get; set; }
        public short? Quantity { get; set; }

        public virtual KvitoGalva Galvos { get; set; }
    }
}
