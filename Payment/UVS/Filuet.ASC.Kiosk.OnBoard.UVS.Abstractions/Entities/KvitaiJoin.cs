using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class KvitaiJoin
    {
        public int KvGid { get; set; }
        public int KvEid { get; set; }
        public int AparatoId { get; set; }
        public int KvitoNr { get; set; }
        public short? Year { get; set; }
        public byte? Month { get; set; }
        public byte? Day { get; set; }
        public byte? Hour { get; set; }
        public byte? Minute { get; set; }
        public byte? ApmokejimoRusis { get; set; }
        public double? Suma { get; set; }
        public double? Nuolaida { get; set; }
        public double? Antkainis { get; set; }
        public double? Mokesciai { get; set; }
        public string KortelesNr { get; set; }
        public int? Kasininkas { get; set; }
        public int? Znr { get; set; }
        public int? PrekesKodas { get; set; }
        public double? Kiekis { get; set; }
        public double? Expr1 { get; set; }
    }
}
