namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{  
    public partial class Price_Discounts_Items
    {
        public int id { get; set; }
        public int KvitoEiluteId { get; set; }
        public double? Discount { get; set; }
        public int? DiscountScenarioType { get; set; }
        public int? DiscountIdentificator { get; set; }
        public int? SellDiscountId { get; set; }
    
        public virtual KvitoEilute KvitoEilute { get; set; }
        public virtual SellDiscount SellDiscount { get; set; }
    }
}
