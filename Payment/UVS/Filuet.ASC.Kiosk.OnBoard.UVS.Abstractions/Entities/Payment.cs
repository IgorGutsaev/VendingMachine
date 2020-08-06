using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Payment()
        {
            this.PaymentBanks = new HashSet<PaymentBank>();
        }
    
        public int id { get; set; }
        public int GalvosId { get; set; }
        public int Type { get; set; }
        public double Amount { get; set; }
        public string CardNo { get; set; }
        public string AuthCode { get; set; }
        public int? AuthModule { get; set; }
        public double? CurrencyRate { get; set; }
        public double? CurrencyAmount { get; set; }
    
        public virtual KvitoGalva KvitoGalva { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentBank> PaymentBanks { get; set; }
    }
}
