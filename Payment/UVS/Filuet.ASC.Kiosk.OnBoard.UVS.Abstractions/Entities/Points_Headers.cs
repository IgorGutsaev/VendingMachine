namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{ 
    public partial class Points_Headers
    {
        public int id { get; set; }
        public int GalvosId { get; set; }
        public double? Points { get; set; }
        public double? CenterPoints { get; set; }
        public int? DiscountIdentificator { get; set; }
    
        public virtual KvitoGalva KvitoGalva { get; set; }
    }
}
