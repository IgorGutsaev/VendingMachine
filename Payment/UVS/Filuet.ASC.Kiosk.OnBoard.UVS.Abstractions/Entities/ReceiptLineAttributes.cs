﻿using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class ReceiptLineAttributes
    {
        public int Id { get; set; }
        public int ReceiptLineId { get; set; }
        public string AttributeId { get; set; }
        public string Value { get; set; }
    }
}
