using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class GetKorteleById
    {
        public string IdNumber { get; set; }
        public short? CardType { get; set; }
        public int? Statusas { get; set; }
        public string Key1B { get; set; }
        public string PusePin { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] Aparatai1 { get; set; }
        public int Id { get; set; }
    }
}
