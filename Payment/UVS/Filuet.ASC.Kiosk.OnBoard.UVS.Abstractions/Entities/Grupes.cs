using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Grupes
    {
        public int GrupesKodas { get; set; }
        public string GrupesPav { get; set; }
        public byte GrupesMokesciai { get; set; }
        public double? Nuolaida1Nuo { get; set; }
        public double? Nuolaida1Proc { get; set; }
        public double? Nuolaida2Nuo { get; set; }
        public double? Nuolaida2Proc { get; set; }
        public byte[] Aparatai { get; set; }
        public int? GrupesKateg { get; set; }
        public byte[] Aparatai1 { get; set; }
        public bool? Aktyvi { get; set; }
        public int GrupesId { get; set; }
        public byte[] Delete { get; set; }
        public byte[] Delete1 { get; set; }
        public bool? NoSavikaina { get; set; }
    }
}
