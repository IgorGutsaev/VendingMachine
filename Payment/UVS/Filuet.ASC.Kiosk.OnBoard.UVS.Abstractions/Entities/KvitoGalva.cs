using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{       
    public partial class KvitoGalva
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KvitoGalva()
        {
            AgeVerifications = new HashSet<AgeVerification>();
            ClientInfoes = new HashSet<ClientInfo>();
            KvitoEilutes = new HashSet<KvitoEilute>();
            Rewards = new HashSet<Reward>();
            Points_Headers = new HashSet<Points_Headers>();
            Payments = new HashSet<Payment>();
            SellDiscounts = new HashSet<SellDiscount>();
            SellEntries = new HashSet<SellEntry>();
        }
    
        public int ID { get; set; }
        public int AparatoID { get; set; }
        public int KvitoNr { get; set; }
        public short? Year { get; set; }
        public byte? Month { get; set; }
        public byte? Day { get; set; }
        public byte? Hour { get; set; }
        public byte? Minute { get; set; }
        public byte? ApmokejimoRusis { get; set; }
        public double? Suma { get; set; }
        public double? Nuolaida { get; set; }
        public double? Antkainis { get; set; }
        public double? Mokesciai { get; set; }
        public string KortelesNr { get; set; }
        public int? Kasininkas { get; set; }
        public int? Znr { get; set; }
        public int? GalvosID { get; set; }
        public string KvitoNr2 { get; set; }
        public string NlKort { get; set; }
        public double? SumaGryni { get; set; }
        public short? Seconds { get; set; }
        public double? Duration { get; set; }
        public double? DurationToPushTotal { get; set; }
        public int? Flags { get; set; }
        public string InvNr { get; set; }
        public string InvNr_Parent { get; set; }
        public int? ReturnReason { get; set; }
        public int? PosOrGroupId_Parent { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgeVerification> AgeVerifications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientInfo> ClientInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KvitoEilute> KvitoEilutes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reward> Rewards { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Points_Headers> Points_Headers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SellDiscount> SellDiscounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SellEntry> SellEntries { get; set; }
    }
}
