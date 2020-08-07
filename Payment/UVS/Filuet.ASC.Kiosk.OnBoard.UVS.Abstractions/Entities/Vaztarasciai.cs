using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Vaztarasciai
    {
        public int Id { get; set; }
        public string Numeris { get; set; }
        public int? Tiekejas { get; set; }
        public DateTime Data { get; set; }
        public string Komentaras { get; set; }
        public bool Registruotas { get; set; }
        public int? Zetas { get; set; }
        public int? Vnr { get; set; }
        public int? AparatoId { get; set; }
        public DateTime? RegistracijosData { get; set; }
        public int? Tipas { get; set; }
        public double? SumaBeNuolaidos { get; set; }
        public double? NuolaidosSuma { get; set; }
        public double? NuolaidosProc { get; set; }
        public double? GavimoPvm { get; set; }
        public byte? Exported { get; set; }
    }
}
