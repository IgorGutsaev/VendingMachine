using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class PluAttributeAssigments
    {
        public int PluCode { get; set; }
        public string AttributeId { get; set; }
        public byte Deleted { get; set; }
        public byte[] Timestamp { get; set; }
    }
}
