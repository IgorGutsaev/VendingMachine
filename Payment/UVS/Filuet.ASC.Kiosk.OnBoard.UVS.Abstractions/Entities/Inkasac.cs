namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{    
    public partial class Inkasac
    {
        public int Id { get; set; }
        public int IdOnPos { get; set; }
        public int POSId { get; set; }
        public System.DateTime OpTime { get; set; }
        public double amount { get; set; }
        public int OpType { get; set; }
        public int ZNr { get; set; }
        public int CashierId { get; set; }
        public string OpName { get; set; }
        public string ObjId { get; set; }
        public string ObjName { get; set; }
    }
}
