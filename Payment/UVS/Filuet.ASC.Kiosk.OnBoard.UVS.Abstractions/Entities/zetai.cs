using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Zetai
    {
        public int Id { get; set; }
        public int Zetas { get; set; }
        public DateTime? Nuo { get; set; }
        public DateTime? Iki { get; set; }
        public DateTime? Kada { get; set; }
        public double? RealizacijosSumaGryni { get; set; }
        public double? GrazintaPrekiuGryni { get; set; }
        public double? SuteiktaNuolaidaGryni { get; set; }
        public double? RealizacijosSumaKorteles { get; set; }
        public double? GrazintaPrekiuKorteles { get; set; }
        public double? SuteiktaNuolaidaKorteles { get; set; }
        public double? Bsapyvarta { get; set; }
        public double? Bsgrazinimai { get; set; }
        public double? Bsrealizacija { get; set; }
        public double? Sgapyvarta { get; set; }
        public double? Sggrazinimai { get; set; }
        public double? Sgrealizacija { get; set; }
        public double? Skapyvarta { get; set; }
        public double? Skgrazinimai { get; set; }
        public double? Skrealizacija { get; set; }
        public int? KvitaiNuo { get; set; }
        public int? KvitaiIki { get; set; }
        public double? KasaPamainosPradzioje { get; set; }
        public double? Realizacija { get; set; }
        public double? Inkasacija { get; set; }
        public double? KasaPamainosPabaigoje { get; set; }
        public string PamainaPerdave { get; set; }
        public string PamainaPrieme { get; set; }
        public double? KitaKort { get; set; }
        public double? KitaGryni { get; set; }
        public double? Viso { get; set; }
        public int Count { get; set; }
        public double? Neapmokestinta { get; set; }
        public double? MokSuma1 { get; set; }
        public double? Mok1 { get; set; }
        public double? MokSuma2 { get; set; }
        public double? Mok2 { get; set; }
        public double? MokSuma3 { get; set; }
        public double? Mok3 { get; set; }
        public double? MokSuma4 { get; set; }
        public double? Mok4 { get; set; }
        public double? MokSuma5 { get; set; }
        public double? Mok5 { get; set; }
    }
}
