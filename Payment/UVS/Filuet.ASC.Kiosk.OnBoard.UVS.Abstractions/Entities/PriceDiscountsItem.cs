using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class PriceDiscountsItem
    {
        public int Id { get; set; }
        public int KvitoEiluteId { get; set; }
        public double? Discount { get; set; }
        public int? DiscountScenarioType { get; set; }
        public int? DiscountIdentificator { get; set; }
        public int? SellDiscountId { get; set; }

        public virtual KvitoEilute KvitoEilute { get; set; }
        public virtual SellDiscount SellDiscount { get; set; }
    }
}
