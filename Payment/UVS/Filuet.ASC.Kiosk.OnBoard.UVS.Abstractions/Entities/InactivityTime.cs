namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{    
    public partial class InactivityTime
    {
        public int id { get; set; }
        public int KvitoEiluteId { get; set; }
        public double? Duration { get; set; }
    
        public virtual KvitoEilute KvitoEilute { get; set; }
    }
}
