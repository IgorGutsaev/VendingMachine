namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{   
    public partial class PrekesScan
    {
        public int? Dep { get; set; }
        public int PrekesKodas { get; set; }
        public bool Aktyvi { get; set; }
        public int? ID { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] C_Aparatai { get; set; }
        public byte[] Delete { get; set; }
        public byte[] C_Delete { get; set; }
        public byte[] AparataiL { get; set; }
        public byte[] C_AparataiL { get; set; }
    }
}
