using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class CouponActivate
    {
        public int Id { get; set; }
        public int Posid { get; set; }
        public int IdOnPos { get; set; }
        public DateTime DateTime { get; set; }
        public string CouponNumber { get; set; }
        public int? ReceiptNr { get; set; }
        public decimal Balance { get; set; }
        public int CashierId { get; set; }
        public int? ClientId { get; set; }
    }
}
