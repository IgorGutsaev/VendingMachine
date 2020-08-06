namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aparatai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aparatai()
        {
            CashierLogs = new HashSet<CashierLog>();
        }
    
        public int AparatoID { get; set; }
        public int? NodeID { get; set; }
        public int? NetworkNr { get; set; }
        public string AparatoPavadinimas { get; set; }
        public int? AparatoNr { get; set; }
        public short? SocketNr { get; set; }
        public int? MyID { get; set; }
        public byte? Type { get; set; }
        public int? NonUVSNumber { get; set; }
        public short? KasaType { get; set; }
        public string FNumber { get; set; }
        public int? Dep { get; set; }
        public string IPAdress { get; set; }
        public string Version { get; set; }
        public string FBVersion { get; set; }
        public int? POSNr { get; set; }
        public string CPUName { get; set; }
        public int? CPUFreq { get; set; }
        public string HardDriveModel { get; set; }
        public string HardDriveSerial { get; set; }
        public double? HardDriveSize_Mb { get; set; }
        public string VideoName { get; set; }
        public int? VideoRAM_Kb { get; set; }
        public int? RAM_Mb { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CashierLog> CashierLogs { get; set; }
    }
}
