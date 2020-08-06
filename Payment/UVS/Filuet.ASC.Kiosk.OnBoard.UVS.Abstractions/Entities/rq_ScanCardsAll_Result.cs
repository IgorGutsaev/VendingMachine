namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class rq_ScanCardsAll_Result
    {
        public string Id_number { get; set; }
        public short? CardType { get; set; }
        public short? CardSubType { get; set; }
        public int? Statusas { get; set; }
        public string Key1B { get; set; }
        public string PusePIN { get; set; }
        public string GroupId { get; set; }
    }
}
