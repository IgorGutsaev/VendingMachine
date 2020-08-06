using System;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{    
    public partial class CouponActivate
    {
        public int Id { get; set; }
        public int POSId { get; set; }
        public int idOnPos { get; set; }
        public DateTime DateTime { get; set; }
        public string CouponNumber { get; set; }
        public int? ReceiptNr { get; set; }
        public decimal Balance { get; set; }
        public int CashierId { get; set; }
        public int? ClientId { get; set; }
    }
}
