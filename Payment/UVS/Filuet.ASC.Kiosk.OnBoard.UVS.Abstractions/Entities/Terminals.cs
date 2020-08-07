using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Terminals
    {
        public string AuthCenter { get; set; }
        public string Merchant { get; set; }
        public string Terminal { get; set; }
        public int? AparatoId { get; set; }
        public int? LastCheckedKvit { get; set; }
        public int? KasosNr { get; set; }
    }
}
