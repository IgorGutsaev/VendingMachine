using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{    
    public partial class SellDiscount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SellDiscount()
        {
            this.Price_Discounts_Items = new HashSet<Price_Discounts_Items>();
        }
    
        public int id { get; set; }
        public int GalvosId { get; set; }
        public int Type { get; set; }
        public int? SubType { get; set; }
        public int? CustNo { get; set; }
        public double? Percent { get; set; }
        public double? Amount { get; set; }
        public string CardNo { get; set; }
        public string DiscountTitle { get; set; }
    
        public virtual KvitoGalva KvitoGalva { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Price_Discounts_Items> Price_Discounts_Items { get; set; }
    }
}
