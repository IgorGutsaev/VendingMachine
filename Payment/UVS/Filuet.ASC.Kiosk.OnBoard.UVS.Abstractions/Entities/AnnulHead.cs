using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{    
    public partial class AnnulHead
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AnnulHead()
        {
            this.AnnulLines = new HashSet<AnnulLine>();
        }
    
        public int Id { get; set; }
        public int POSId { get; set; }
        public int IdOnPos { get; set; }
        public int CheckNr { get; set; }
        public int ZNr { get; set; }
        public int CashierId { get; set; }
        public System.DateTime AnnulTime { get; set; }
        public int AnnulType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnnulLine> AnnulLines { get; set; }
    }
}
