namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class CompPLU
    {
        public int ID { get; set; }
        public int Dep { get; set; }
        public int MainCode { get; set; }
        public string SupCode { get; set; }
        public double Coef { get; set; }
        public int SupType { get; set; }
    }
}
