namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{  
    public partial class Tomra_Log
    {
        public int Id { get; set; }
        public System.DateTime When { get; set; }
        public string TerminalId { get; set; }
        public int STAN { get; set; }
        public string Operation { get; set; }
        public string Barcode { get; set; }
        public string TomraResponse { get; set; }
    }
}
