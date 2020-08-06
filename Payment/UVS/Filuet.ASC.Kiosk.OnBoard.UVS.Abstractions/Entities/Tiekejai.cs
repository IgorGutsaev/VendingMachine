namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{  
    public partial class Tiekejai
    {
        public int ID { get; set; }
        public string Pavadinimas { get; set; }
        public int? IsorinisKodas { get; set; }
        public int? VidinisKodas { get; set; }
        public int? Antkainis { get; set; }
        public int? Nuolaida { get; set; }
        public string Telefonai { get; set; }
        public string PVMKodas { get; set; }
        public string ImKodas { get; set; }
        public string Adresas { get; set; }
        public int? SaskaitosNr { get; set; }
        public string BankoKodas { get; set; }
    }
}
