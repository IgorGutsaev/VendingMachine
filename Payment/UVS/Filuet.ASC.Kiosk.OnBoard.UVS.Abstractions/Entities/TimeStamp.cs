using System;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{ 
    public partial class TimeStamp
    {
        public int id { get; set; }
        public string Module { get; set; }
        public int ApID { get; set; }
        public byte[] Value { get; set; }
        public DateTime Updated { get; set; }
    }
}
