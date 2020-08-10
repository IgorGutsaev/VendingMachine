using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class PlusetLine
    {
        public int Id { get; set; }
        public int Dep { get; set; }
        public int Setno { get; set; }
        public string Barcode { get; set; }
        public double Qty { get; set; }
        public double Price { get; set; }
        public double Tax { get; set; }
        public double Packcount { get; set; }
        public byte? PriceMode { get; set; }
    }
}
