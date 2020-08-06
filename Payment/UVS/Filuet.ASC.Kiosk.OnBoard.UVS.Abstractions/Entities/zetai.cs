namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    using System;
    public partial class zetai
    {
        public int ID { get; set; }
        public int Zetas { get; set; }
        public DateTime? NUO { get; set; }
        public DateTime? IKI { get; set; }
        public DateTime? KADA { get; set; }
        public double? Realizacijos_suma_gryni { get; set; }
        public double? Grazinta_prekiu_gryni { get; set; }
        public double? Suteikta_nuolaida_gryni { get; set; }
        public double? Realizacijos_suma_korteles { get; set; }
        public double? Grazinta_prekiu_korteles { get; set; }
        public double? Suteikta_nuolaida_korteles { get; set; }
        public double? BSapyvarta { get; set; }
        public double? BSgrazinimai { get; set; }
        public double? BSrealizacija { get; set; }
        public double? SGapyvarta { get; set; }
        public double? SGgrazinimai { get; set; }
        public double? SGrealizacija { get; set; }
        public double? SKapyvarta { get; set; }
        public double? SKgrazinimai { get; set; }
        public double? SKrealizacija { get; set; }
        public int? KvitaiNuo { get; set; }
        public int? KvitaiIki { get; set; }
        public double? Kasa_pamainos_pradzioje { get; set; }
        public double? Realizacija { get; set; }
        public double? Inkasacija { get; set; }
        public double? Kasa_pamainos_pabaigoje { get; set; }
        public string Pamaina_perdave { get; set; }
        public string Pamaina_prieme { get; set; }
        public double? Kita_kort { get; set; }
        public double? Kita_gryni { get; set; }
        public double? Viso { get; set; }
        public int COUNT { get; set; }
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
