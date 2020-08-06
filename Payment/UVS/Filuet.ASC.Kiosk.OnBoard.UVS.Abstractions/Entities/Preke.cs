using System;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{ 
    public partial class Preke
    {
        public string PrekesPavadinimas { get; set; }
        public string PrekesKomentaras { get; set; }
        public double PrekesKaina { get; set; }
        public byte? PrekesMatas { get; set; }
        public double PrekesKiekis { get; set; }
        public int PrekesKodas { get; set; }
        public int GrupesID { get; set; }
        public bool Aktyvi { get; set; }
        public byte[] Aparatai { get; set; }
        public DateTime? Laikas { get; set; }
        public int? GlobalID { get; set; }
        public int ID { get; set; }
        public byte[] C_Aparatai { get; set; }
        public byte[] AparataiL { get; set; }
        public byte[] C_AparataiL { get; set; }
        public byte[] Delete { get; set; }
        public byte[] C_Delete { get; set; }
        public double? MinKiekis { get; set; }
        public int? TiekejoID { get; set; }
        public short? N_Type { get; set; }
        public double? N_1_Nuo { get; set; }
        public double? N_1_Kiek { get; set; }
        public double? N_2_Nuo { get; set; }
        public double? N_2_Kiek { get; set; }
        public double? PrekesKaina2 { get; set; }
        public double? DidmenineKaina { get; set; }
        public double? DidmenineKaina2 { get; set; }
        public int? Dep { get; set; }
        public bool? Updating { get; set; }
        public short PriceType { get; set; }
        public int BlockType { get; set; }
    }
}
