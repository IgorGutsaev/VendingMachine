using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class StartLikuciai
    {
        public int Id { get; set; }
        public int? PrKodas { get; set; }
        public double? PrLikutis { get; set; }
        public int? ApId { get; set; }
    }
}
