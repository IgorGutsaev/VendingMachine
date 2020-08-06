namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{    
    public partial class EuroStage
    {
        public int Id { get; set; }
        public int PosId { get; set; }
        public int StageNr { get; set; }
        public System.DateTime When { get; set; }
    }
}
