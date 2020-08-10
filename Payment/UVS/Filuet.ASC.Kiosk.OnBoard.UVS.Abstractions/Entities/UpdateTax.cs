using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class UpdateTax
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double? Tax { get; set; }
        public byte? Mask { get; set; }
        public byte? Priority { get; set; }
        public DateTime? ValidFrom { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] Aparatai1 { get; set; }
        public byte[] Delete { get; set; }
        public byte[] Delete1 { get; set; }
    }
}
