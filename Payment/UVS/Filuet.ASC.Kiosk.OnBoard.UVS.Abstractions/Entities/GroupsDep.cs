namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{    
    public partial class GroupsDep
    {
        public int ID { get; set; }
        public string PLUGroup { get; set; }
        public string Dep { get; set; }
        public string Pav { get; set; }
        public bool DoNotSendToScales { get; set; }
    }
}
