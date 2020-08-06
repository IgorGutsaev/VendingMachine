namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{    
    public partial class GrupesScan
    {
        public int GrupesKodas { get; set; }
        public bool? Aktyvi { get; set; }
        public int? GrupesID { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] C_Aparatai { get; set; }
        public byte[] Delete { get; set; }
        public byte[] C_Delete { get; set; }
    }
}
