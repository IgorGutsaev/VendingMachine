using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class TomraLog
    {
        public int Id { get; set; }
        public DateTime When { get; set; }
        public string TerminalId { get; set; }
        public int Stan { get; set; }
        public string Operation { get; set; }
        public string Barcode { get; set; }
        public string TomraResponse { get; set; }
    }
}
