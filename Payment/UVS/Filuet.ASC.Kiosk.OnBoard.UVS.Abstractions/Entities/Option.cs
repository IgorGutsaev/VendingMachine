using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Option
    {
        public int Id { get; set; }
        public int? LastKvitaiCounter { get; set; }
        public int? LastPrekesCounter { get; set; }
        public int? LastGrupesCounter { get; set; }
        public int? LastVaztarasciaiCounter { get; set; }
        public string FirmosPavadinimas { get; set; }
        public int? DallasPort { get; set; }
        public int? ScotPort { get; set; }
        public int? ScotMotherPort { get; set; }
        public int? ScotBatchPort { get; set; }
        public int? EmitentoKodas { get; set; }
        public int? DefaultStatus { get; set; }
        public double? Pvm { get; set; }
        public int? OrganizacijosId { get; set; }
        public string ExternalDb { get; set; }
        public int? LastTimeDelta { get; set; }
        public bool AutoGroupSend { get; set; }
        public int? LastEcrcounter { get; set; }
        public string VaztExportDir { get; set; }
        public int? DegalinesId { get; set; }
        public bool VaztAutoPrint { get; set; }
        public bool VaztAutoSend { get; set; }
        public string ExportNewCardsPath { get; set; }
        public int? SendBarcodesToCenter { get; set; }
        public int? LastBarCodeExportCounter { get; set; }
        public DateTime? LastLogExportDate { get; set; }
        public string AutoVaztTiekejoId { get; set; }
        public double? MinCash { get; set; }
        public bool GenSavikaina { get; set; }
        public int? LastKvitoIdforSavikaina { get; set; }
        public bool KorKurLik { get; set; }
        public int? LastKavcounter { get; set; }
        public string FakturaFooter { get; set; }
        public string FakturaHeader { get; set; }
        public bool AllowFuelGroupEditions { get; set; }
        public bool AllowNonZeroQdeletions { get; set; }
        public bool KorVaztModeZ { get; set; }
        public int? LastVaztExpId { get; set; }
        public bool LeistiSavikainaNeigiamiems { get; set; }
        public int? LastVaztSarExportCounter { get; set; }
    }
}
