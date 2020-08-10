using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class ReceiptHeadAttributeAssignments
    {
        public string AttributeId { get; set; }
        public byte Deleted { get; set; }
        public byte[] Timestamp { get; set; }
    }
}
