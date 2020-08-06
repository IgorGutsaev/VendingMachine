using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{    
    public partial class KvitoEilute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KvitoEilute()
        {
            InactivityTimes = new HashSet<InactivityTime>();
            Price_Discounts_Items = new HashSet<Price_Discounts_Items>();
            Points_Items = new HashSet<Points_Items>();
        }
    
        public int ID { get; set; }
        public int GalvosID { get; set; }
        public int? PrekesKodas { get; set; }
        public double? Kiekis { get; set; }
        public double? Kaina { get; set; }
        public double? Suma { get; set; }
        public double? Mokesciai { get; set; }
        public double? Nuolaida { get; set; }
        public int? PrekesID { get; set; }
        public string Barkodas { get; set; }
        public double? VietDez { get; set; }
        public double? Savikaina { get; set; }
        public double? RealKaina { get; set; }
        public int? PriceOption { get; set; }
        public int? VAT { get; set; }
        public int? SellFlags { get; set; }
        public int? LineNumber { get; set; }
        public double? Duration { get; set; }
        public short? PriceType { get; set; }
        public string PriceOriginType { get; set; }
        public long? PriceIdentificator { get; set; }
        public string PackerID { get; set; }
        public double? MPValueGranted { get; set; }
        public double? MPValuePaid { get; set; }
        public string StrCode { get; set; }
        public int? ParentLineNo { get; set; }
        public int? OriginalLineNo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InactivityTime> InactivityTimes { get; set; }
        public virtual KvitoGalva KvitoGalva { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Price_Discounts_Items> Price_Discounts_Items { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Points_Items> Points_Items { get; set; }
    }
}
