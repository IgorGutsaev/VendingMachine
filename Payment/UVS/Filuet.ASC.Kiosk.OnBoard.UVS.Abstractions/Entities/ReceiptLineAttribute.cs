namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{ 
    public partial class ReceiptLineAttribute
    {
        public int Id { get; set; }
        public int ReceiptLineId { get; set; }
        public string AttributeId { get; set; }
        public string Value { get; set; }
    }
}
