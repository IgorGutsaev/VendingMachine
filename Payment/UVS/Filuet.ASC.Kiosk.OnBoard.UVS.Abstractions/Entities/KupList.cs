namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    using System;
    
    public partial class KupList
    {
        public int ID { get; set; }
        public int? AparatoID { get; set; }
        public int? Kasininkas { get; set; }
        public int? KvitoNr { get; set; }
        public DateTime? Laikas { get; set; }
        public double? Suma { get; set; }
        public double? Nuolaida { get; set; }
        public string Kuponas { get; set; }
        public int? Kiekis { get; set; }
        public int? Tipas { get; set; }
    }
}
