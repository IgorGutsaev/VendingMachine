using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class CashierLogs
    {
        public int Id { get; set; }
        public int CashierId { get; set; }
        public int AparatoId { get; set; }
        public DateTime? LogOnTime { get; set; }
        public DateTime? LogOffTime { get; set; }
        public int IdOnPos { get; set; }

        public virtual Aparatai Aparato { get; set; }
    }
}
