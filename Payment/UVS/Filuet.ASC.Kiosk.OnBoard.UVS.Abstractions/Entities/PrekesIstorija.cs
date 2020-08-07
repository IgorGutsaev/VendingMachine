using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class PrekesIstorija
    {
        public int Id { get; set; }
        public DateTime? Laikas { get; set; }
        public int? PrekesKodas { get; set; }
        public int? PrekesId { get; set; }
        public int? Operacija { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public short? Tipas { get; set; }
        public int? SubOperacija { get; set; }
    }
}
