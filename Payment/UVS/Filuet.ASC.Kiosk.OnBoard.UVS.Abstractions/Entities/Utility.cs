namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{  
    public partial class Utility
    {
        public int id { get; set; }
        public int Dep { get; set; }
        public int KasosNr { get; set; }
        public int Kasininkas { get; set; }
        public int GalvosID { get; set; }
        public int KvitoNr { get; set; }
        public double Suma { get; set; }
        public string ServiceBarcode { get; set; }
        public string GoodsBarcode { get; set; }
        public System.DateTime Laikas { get; set; }
        public int? EilNr { get; set; }
    }
}
