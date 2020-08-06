namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{    
    public partial class Aurimas_NK
    {
        public int ID { get; set; }
        public int AparatoID { get; set; }
        public int? Dep { get; set; }
        public int KvitoNr { get; set; }
        public short? Year { get; set; }
        public byte? Month { get; set; }
        public byte? Day { get; set; }
        public byte? Hour { get; set; }
        public byte? Minute { get; set; }
        public int? PrekesKodas { get; set; }
        public double? Kiekis { get; set; }
        public double? Kaina { get; set; }
        public double? Suma { get; set; }
        public double? Mokesciai { get; set; }
        public double? Nuolaida { get; set; }
        public string Barkodas { get; set; }
        public double? VietDez { get; set; }
        public byte? ApmokejimoRusis { get; set; }
        public string KortelesNr { get; set; }
        public int? Kasininkas { get; set; }
        public int? Znr { get; set; }
    }
}
