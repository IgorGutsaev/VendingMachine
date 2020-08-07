using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class PlusetAttribute
    {
        public int PlusetId { get; set; }
        public string AttributeId { get; set; }
        public string Value { get; set; }
    }
}
