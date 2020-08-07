using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class SellDiscount
    {
        public SellDiscount()
        {
            PriceDiscountsItems = new HashSet<PriceDiscountsItem>();
        }

        public int Id { get; set; }
        public int GalvosId { get; set; }
        public int Type { get; set; }
        public int? SubType { get; set; }
        public int? CustNo { get; set; }
        public double? Percent { get; set; }
        public double? Amount { get; set; }
        public string CardNo { get; set; }
        public string DiscountTitle { get; set; }

        public virtual KvitoGalva Galvos { get; set; }
        public virtual ICollection<PriceDiscountsItem> PriceDiscountsItems { get; set; }
    }
}
