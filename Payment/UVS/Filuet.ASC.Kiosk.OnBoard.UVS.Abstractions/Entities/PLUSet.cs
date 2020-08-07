using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Pluset
    {
        public int Id { get; set; }
        public int Dep { get; set; }
        public int SetNo { get; set; }
        public string Barcode { get; set; }
        public int Pricemode { get; set; }
        public string Paytype { get; set; }
        public DateTime? Createdate { get; set; }
        public int Reservation { get; set; }
        public int Pickuplace { get; set; }
        public string Customer { get; set; }
        public int Kgid { get; set; }
    }
}
