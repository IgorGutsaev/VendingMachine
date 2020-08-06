namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{ 
    public partial class PluAttributeAssigment
    {
        public int PluCode { get; set; }
        public string AttributeId { get; set; }
        public byte Deleted { get; set; }
        public byte[] Timestamp { get; set; }
    }
}
