namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class rq_ScanGrupesAll_Result
    {
        public int GrupesKodas { get; set; }
        public string GrupesPav { get; set; }
        public byte GrupesMokesciai { get; set; }
        public double? Nuolaida1Proc { get; set; }
        public double? Nuolaida1Nuo { get; set; }
        public double? Nuolaida2Nuo { get; set; }
        public double? Nuolaida2Proc { get; set; }
        public int? GrupesKateg { get; set; }
    }
}
