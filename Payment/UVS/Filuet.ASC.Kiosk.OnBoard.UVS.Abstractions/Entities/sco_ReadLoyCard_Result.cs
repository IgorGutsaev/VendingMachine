namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{  
    public partial class sco_ReadLoyCard_Result
    {
        public int ID { get; set; }
        public string CardNo { get; set; }
        public int? Status { get; set; }
        public string GroupId { get; set; }
    }
}
