using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class TimeStamp
    {
        public int Id { get; set; }
        public string Module { get; set; }
        public int ApId { get; set; }
        public byte[] Value { get; set; }
        public DateTime Updated { get; set; }
    }
}
