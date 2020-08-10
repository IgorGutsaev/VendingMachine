using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class GetPrekeById
    {
        public string PrekesPavadinimas { get; set; }
        public string PrekesKomentaras { get; set; }
        public double PrekesKaina { get; set; }
        public byte? PrekesMatas { get; set; }
        public double PrekesKiekis { get; set; }
        public int PrekesKodas { get; set; }
        public int GrupesId { get; set; }
        public bool Aktyvi { get; set; }
        public byte[] Aparatai { get; set; }
        public DateTime? Laikas { get; set; }
        public int? GlobalId { get; set; }
        public int Id { get; set; }
        public byte[] Aparatai1 { get; set; }
        public byte[] AparataiL { get; set; }
        public byte[] AparataiL1 { get; set; }
        public byte[] Delete { get; set; }
        public byte[] Delete1 { get; set; }
        public double? MinKiekis { get; set; }
        public int? TiekejoId { get; set; }
        public short? NType { get; set; }
        public double? N1Nuo { get; set; }
        public double? N1Kiek { get; set; }
        public double? N2Nuo { get; set; }
        public double? N2Kiek { get; set; }
        public double? PrekesKaina2 { get; set; }
        public double? DidmenineKaina { get; set; }
        public double? DidmenineKaina2 { get; set; }
        public int? Dep { get; set; }
        public bool? Updating { get; set; }
        public int GrupesKodas { get; set; }
    }
}
