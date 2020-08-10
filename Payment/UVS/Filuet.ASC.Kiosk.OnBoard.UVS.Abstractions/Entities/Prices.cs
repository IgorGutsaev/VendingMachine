using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Prices
    {
        public int Id { get; set; }
        public int Dep { get; set; }
        public int Plucode { get; set; }
        public double Price { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
    }
}
