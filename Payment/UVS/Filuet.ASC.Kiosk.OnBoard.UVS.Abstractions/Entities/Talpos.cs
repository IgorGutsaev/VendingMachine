using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Talpos
    {
        public int? RezervuaroNr { get; set; }
        public int? Kodas { get; set; }
        public double? KompiuterioLikutis { get; set; }
        public double? TalposDydis { get; set; }
        public double? TurisNeperskaiciuotas { get; set; }
        public double? TurisPerskaiciuotas { get; set; }
        public double? Temperatura { get; set; }
        public double? Lygis { get; set; }
        public double? VandensLygis { get; set; }
        public DateTime? MatavimoLaikas { get; set; }
        public bool? IsDevice { get; set; }
        public int? PrekyvId { get; set; }
        public int? Zetas { get; set; }
        public int Id { get; set; }
    }
}
