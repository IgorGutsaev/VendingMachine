using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class PlusetLineAttributes
    {
        public int PlusetLineId { get; set; }
        public string AttributeId { get; set; }
        public string Value { get; set; }
    }
}
