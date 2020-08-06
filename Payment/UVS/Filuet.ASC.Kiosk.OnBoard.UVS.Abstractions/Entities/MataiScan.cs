namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{  
    public partial class MataiScan
    {
        public byte MatoKodas { get; set; }
        public byte Aktyvi { get; set; }
        public int? MatoID { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] C_Aparatai { get; set; }
        public byte[] Delete { get; set; }
        public byte[] C_Delete { get; set; }
    }
}
