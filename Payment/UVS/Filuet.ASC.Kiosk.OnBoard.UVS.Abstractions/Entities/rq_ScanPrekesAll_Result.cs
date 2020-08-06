namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{ 
    public partial class rq_ScanPrekesAll_Result
    {
        public int PrekesKodas { get; set; }
        public int? Dep { get; set; }
        public int ID { get; set; }
        public string PrekesPavadinimas { get; set; }
        public string PrekesKomentaras { get; set; }
        public double PrekesKaina { get; set; }
        public byte? PrekesMatas { get; set; }
        public int GrupesKodas { get; set; }
        public short? N_Type { get; set; }
        public double? N_1_Nuo { get; set; }
        public double? N_1_Kiek { get; set; }
        public double? N_2_Nuo { get; set; }
        public double? N_2_Kiek { get; set; }
        public double? PrekesKaina2 { get; set; }
        public double? DidmenineKaina { get; set; }
        public double? DidmenineKaina2 { get; set; }
        public string BarCode { get; set; }
    }
}
