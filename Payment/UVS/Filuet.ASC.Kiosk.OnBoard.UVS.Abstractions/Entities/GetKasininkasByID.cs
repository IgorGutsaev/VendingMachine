using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class GetKasininkasById
    {
        public string Kodas { get; set; }
        public string Pavarde { get; set; }
        public short? Lygis { get; set; }
        public int VidinisNr { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] Aparatai1 { get; set; }
        public byte[] Delete { get; set; }
        public byte[] Delete1 { get; set; }
        public byte? Aktyvi { get; set; }
        public int Id { get; set; }
        public int? Dep { get; set; }
    }
}
