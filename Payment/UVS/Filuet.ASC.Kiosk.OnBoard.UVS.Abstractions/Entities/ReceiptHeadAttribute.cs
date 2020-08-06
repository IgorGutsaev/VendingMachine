namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{ 
    public partial class ReceiptHeadAttribute
    {
        public int Id { get; set; }
        public int ReceiptHeadId { get; set; }
        public string AttributeId { get; set; }
        public string Value { get; set; }
    }
}
