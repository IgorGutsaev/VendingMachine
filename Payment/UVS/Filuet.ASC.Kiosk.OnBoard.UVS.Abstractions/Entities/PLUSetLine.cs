namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{   
    public partial class PLUSetLine
    {
        public int ID { get; set; }
        public int dep { get; set; }
        public int setno { get; set; }
        public string BARCODE { get; set; }
        public double qty { get; set; }
        public double price { get; set; }
        public double tax { get; set; }
        public double packcount { get; set; }
        public byte? PriceMode { get; set; }
    }
}
