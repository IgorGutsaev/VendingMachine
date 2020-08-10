using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class PrekesScan
    {
        public int? Dep { get; set; }
        public int PrekesKodas { get; set; }
        public bool Aktyvi { get; set; }
        public int? Id { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] Aparatai1 { get; set; }
        public byte[] Delete { get; set; }
        public byte[] Delete1 { get; set; }
        public byte[] AparataiL { get; set; }
        public byte[] AparataiL1 { get; set; }
    }
}
