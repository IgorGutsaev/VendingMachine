namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{  
    public partial class VaztarascioEilute
    {
        public int ID { get; set; }
        public int? VaztarascioID { get; set; }
        public int? PrekesKodas { get; set; }
        public int? PrekesID { get; set; }
        public double? Kiekis { get; set; }
        public double? GavimoKaina { get; set; }
        public int? GavimoForma { get; set; }
        public double? PardavimoKaina { get; set; }
        public double? GavimoSuma { get; set; }
    }
}
