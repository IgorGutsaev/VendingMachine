using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Payment
    {
        public Payment()
        {
            PaymentBank = new HashSet<PaymentBank>();
        }

        public int Id { get; set; }
        public int GalvosId { get; set; }
        public int Type { get; set; }
        public double Amount { get; set; }
        public string CardNo { get; set; }
        public string AuthCode { get; set; }
        public int? AuthModule { get; set; }
        public double? CurrencyRate { get; set; }
        public double? CurrencyAmount { get; set; }

        public virtual KvitoGalva Galvos { get; set; }
        public virtual ICollection<PaymentBank> PaymentBank { get; set; }
    }
}
