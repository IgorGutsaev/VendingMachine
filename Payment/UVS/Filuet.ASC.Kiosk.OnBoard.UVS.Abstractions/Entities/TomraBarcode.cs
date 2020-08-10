using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class TomraBarcode
    {
        public int Id { get; set; }
        public string TerminalId { get; set; }
        public int Stan { get; set; }
        public string Barcode { get; set; }
        public string ReceiptNr { get; set; }
        public int Status { get; set; }
        public string TomraReceiptId { get; set; }
    }
}
