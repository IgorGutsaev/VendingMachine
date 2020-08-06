using System;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{  
    public partial class Price
    {
        public int Id { get; set; }
        public int Dep { get; set; }
        public int PLUcode { get; set; }
        public double Price1 { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
    }
}
