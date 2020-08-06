using System;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class NaujienosSvarstyklem
    {
        public int ID { get; set; }
        public int? PrekK { get; set; }
        public string Barcode { get; set; }
        public int? PrekesEilNr { get; set; }
        public string PrekesPav { get; set; }
        public double? Price { get; set; }
        public int? ScGroup { get; set; }
        public DateTime? Laikas { get; set; }
        public string Comment { get; set; }
        public int? ShelfLife { get; set; }
        public string Sudetis { get; set; }
        public string TechSalygos { get; set; }
        public string LaikymoSalygos { get; set; }
        public int? RealizValand { get; set; }
        public string PLUGroup { get; set; }
        public int? Remove { get; set; }
        public string Gamintojas { get; set; }
        public string EnergetineVerte { get; set; }
        public string Ypatybes { get; set; }
        public string Aprasas2 { get; set; }
        public bool Weight { get; set; }
        public double? GraduatedPrice { get; set; }
        public double? GraduatePoint { get; set; }
        public double? Price2 { get; set; }
        public int? Group2 { get; set; }
        public int? Group3 { get; set; }
        public string Sudetis2 { get; set; }
    }
}
