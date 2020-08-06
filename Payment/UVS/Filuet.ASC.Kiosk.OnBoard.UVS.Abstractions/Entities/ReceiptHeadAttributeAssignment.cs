namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{ 
    public partial class ReceiptHeadAttributeAssignment
    {
        public string AttributeId { get; set; }
        public byte Deleted { get; set; }
        public byte[] Timestamp { get; set; }
    }
}
