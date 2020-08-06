namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{    
    public partial class GetKasininkasByID
    {
        public string Kodas { get; set; }
        public string Pavarde { get; set; }
        public short? Lygis { get; set; }
        public int VidinisNr { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] C_Aparatai { get; set; }
        public byte[] Delete { get; set; }
        public byte[] C_Delete { get; set; }
        public byte? Aktyvi { get; set; }
        public int ID { get; set; }
        public int? Dep { get; set; }
    }
}
