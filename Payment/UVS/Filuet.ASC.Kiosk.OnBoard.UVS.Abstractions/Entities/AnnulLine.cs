using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class AnnulLine
    {
        public int Id { get; set; }
        public int HeadId { get; set; }
        public int LineNumber { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public double Count { get; set; }
        public double Discount { get; set; }
        public double VatAmount { get; set; }
        public int VatType { get; set; }
        public string BarCode { get; set; }
        public double PackCount { get; set; }
        public double RealPrice { get; set; }
        public int PriceOption { get; set; }

        public virtual AnnulHead Head { get; set; }
    }
}
