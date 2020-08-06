namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{ 
    public partial class Reward
    {
        public int id { get; set; }
        public int GalvosId { get; set; }
        public int? DiscountIdentificator { get; set; }
        public string RewardIdentificator { get; set; }
        public string CouponBarcode { get; set; }
        public bool? IsGsm { get; set; }
        public short? Quantity { get; set; }
    
        public virtual KvitoGalva KvitoGalva { get; set; }
    }
}
