using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class UpdateFh
    {
        public int Id { get; set; }
        public bool FooterHeader { get; set; }
        public string Text { get; set; }
        public byte Line { get; set; }
        public byte? Font { get; set; }
        public DateTime? ValidFrom { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] Aparatai1 { get; set; }
    }
}
