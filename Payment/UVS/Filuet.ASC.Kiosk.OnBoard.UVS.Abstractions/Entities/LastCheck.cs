namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class LastCheck
    {
        public int AparatoID { get; set; }
        public string AparatoPavadinimas { get; set; }
        public int? MaxKv { get; set; }
        public short? Year { get; set; }
        public byte? Month { get; set; }
        public byte? Day { get; set; }
        public byte? Hour { get; set; }
        public byte? Minute { get; set; }
    }
}
