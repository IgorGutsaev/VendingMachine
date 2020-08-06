namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{  
    public partial class StartParam
    {
        public int ID { get; set; }
        public int ApID { get; set; }
        public int ZNr { get; set; }
        public int KvNr { get; set; }
        public bool Valid { get; set; }
        public bool Continue { get; set; }
    }
}
