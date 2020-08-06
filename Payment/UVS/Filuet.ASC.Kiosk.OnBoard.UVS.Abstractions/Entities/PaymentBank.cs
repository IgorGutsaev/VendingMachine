namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{ 
    public partial class PaymentBank
    {
        public int id { get; set; }
        public int PaymentId { get; set; }
        public short? BankId { get; set; }
        public short? BankOwnerId { get; set; }
        public bool? IsCobrand { get; set; }
        public bool? IsOnline { get; set; }
        public string AuthId { get; set; }
        public string Ci { get; set; }
    
        public virtual Payment Payment { get; set; }
    }
}
