using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class MataiScan
    {
        public byte MatoKodas { get; set; }
        public byte Aktyvi { get; set; }
        public int? MatoId { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] Aparatai1 { get; set; }
        public byte[] Delete { get; set; }
        public byte[] Delete1 { get; set; }
    }
}
