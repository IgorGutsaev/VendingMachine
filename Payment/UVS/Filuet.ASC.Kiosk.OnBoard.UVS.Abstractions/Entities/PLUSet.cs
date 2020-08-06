using System;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class PLUSet
    {
        public int ID { get; set; }
        public int dep { get; set; }
        public int setNo { get; set; }
        public string barcode { get; set; }
        public int pricemode { get; set; }
        public string paytype { get; set; }
        public DateTime? createdate { get; set; }
        public int reservation { get; set; }
        public int pickuplace { get; set; }
        public string customer { get; set; }
        public int KGID { get; set; }
    }
}
