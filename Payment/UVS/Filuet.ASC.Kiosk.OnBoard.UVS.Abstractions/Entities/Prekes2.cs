namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{  
    public partial class Prekes2
    {
        public int id { get; set; }
        public int PrekesId { get; set; }
        public double? Price5 { get; set; }
        public double? Price6 { get; set; }
        public double? Price7 { get; set; }
        public string ManufacId { get; set; }
        public string ItemGroupId { get; set; }
        public string BrandId { get; set; }
        public int? Flags { get; set; }
        public string PriceOriginType { get; set; }
        public long? PriceIdentificator { get; set; }
    }
}
