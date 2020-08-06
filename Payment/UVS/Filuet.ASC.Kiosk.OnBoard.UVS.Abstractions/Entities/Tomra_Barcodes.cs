namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{  
    public partial class Tomra_Barcodes
    {
        public int Id { get; set; }
        public string TerminalId { get; set; }
        public int STAN { get; set; }
        public string Barcode { get; set; }
        public string ReceiptNr { get; set; }
        public int status { get; set; }
        public string TomraReceiptId { get; set; }
    }
}
