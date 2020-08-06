using System;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class PrekesIstorija
    {
        public int ID { get; set; }
        public DateTime? Laikas { get; set; }
        public int? PrekesKodas { get; set; }
        public int? PrekesID { get; set; }
        public int? Operacija { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public short? Tipas { get; set; }
        public int? SubOperacija { get; set; }
    }
}
