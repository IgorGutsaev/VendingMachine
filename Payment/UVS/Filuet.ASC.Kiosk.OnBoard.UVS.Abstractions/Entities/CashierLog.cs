using System;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{    
    public partial class CashierLog
    {
        public int id { get; set; }
        public int CashierId { get; set; }
        public int AparatoId { get; set; }
        public DateTime? LogOnTime { get; set; }
        public DateTime? LogOffTime { get; set; }
        public int IdOnPos { get; set; }
    
        public virtual Aparatai Aparatai { get; set; }
    }
}
