using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class KupList
    {
        public int Id { get; set; }
        public int? AparatoId { get; set; }
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
