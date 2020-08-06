namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{  
    public partial class Points_Items
    {
        public int id { get; set; }
        public int KvitoEiluteId { get; set; }
        public double? Points { get; set; }
        public int? DiscountIdentificator { get; set; }
    
        public virtual KvitoEilute KvitoEilute { get; set; }
    }
}
