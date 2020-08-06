namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{  
    public partial class Skaitliukai
    {
        public int ID { get; set; }
        public int? AparatoID { get; set; }
        public int? Zetas { get; set; }
        public string Pistoletas { get; set; }
        public int? Benzinas { get; set; }
        public double? Skaitliukas { get; set; }
        public double? KiekisGryni { get; set; }
        public double? KiekisKort { get; set; }
        public double? KiekisTech { get; set; }
        public double? KiekisOver { get; set; }
        public int? IDZ { get; set; }
        public short? PistNr { get; set; }
        public short? TankNr { get; set; }
    }
}
