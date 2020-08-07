using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class UpdatePlu
    {
        public int Id { get; set; }
        public int? Dep { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int Code { get; set; }
        public string BarCode { get; set; }
        public decimal Price1 { get; set; }
        public decimal? Price2 { get; set; }
        public decimal? Price3 { get; set; }
        public decimal? Price4 { get; set; }
        public double? Tax1 { get; set; }
        public double? Tax2 { get; set; }
        public double? Tax3 { get; set; }
        public double? Tax4 { get; set; }
        public string UnitName { get; set; }
        public int? UnitCode { get; set; }
        public byte? UnitScale { get; set; }
        public string GroupName { get; set; }
        public string GroupCode { get; set; }
        public int? GroupTax { get; set; }
        public int? GroupCat { get; set; }
        public double? GroupDiscount1qty { get; set; }
        public double? GroupDiscount1amount { get; set; }
        public double? GroupDiscount2qty { get; set; }
        public double? GroupDiscount2amount { get; set; }
        public int? DiscountType { get; set; }
        public double? Discount1qty { get; set; }
        public double? Discount1amount { get; set; }
        public double? Discount2qty { get; set; }
        public double? Discount2amount { get; set; }
        public byte? ToScales { get; set; }
        public byte? Weighting { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? ValidFrom { get; set; }
        public int? Veiksmas { get; set; }
    }
}
