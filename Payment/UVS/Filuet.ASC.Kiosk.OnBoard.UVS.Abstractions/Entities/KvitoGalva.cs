using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class KvitoGalva
    {
        public KvitoGalva()
        {
            AgeVerification = new HashSet<AgeVerification>();
            ClientInfo = new HashSet<ClientInfo>();
            KvitoEilute = new HashSet<KvitoEilute>();
            Payment = new HashSet<Payment>();
            PointsHeaders = new HashSet<PointsHeaders>();
            Reward = new HashSet<Reward>();
            SellDiscount = new HashSet<SellDiscount>();
            SellEntry = new HashSet<SellEntry>();
        }

        public int Id { get; set; }
        public int AparatoId { get; set; }
        public int KvitoNr { get; set; }
        public short? Year { get; set; }
        public byte? Month { get; set; }
        public byte? Day { get; set; }
        public byte? Hour { get; set; }
        public byte? Minute { get; set; }
        public byte? ApmokejimoRusis { get; set; }
        public double? Suma { get; set; }
        public double? Nuolaida { get; set; }
        public double? Antkainis { get; set; }
        public double? Mokesciai { get; set; }
        public string KortelesNr { get; set; }
        public int? Kasininkas { get; set; }
        public int? Znr { get; set; }
        public int? GalvosId { get; set; }
        public string KvitoNr2 { get; set; }
        public string NlKort { get; set; }
        public double? SumaGryni { get; set; }
        public short? Seconds { get; set; }
        public double? Duration { get; set; }
        public double? DurationToPushTotal { get; set; }
        public int? Flags { get; set; }
        public string InvNr { get; set; }
        public string InvNrParent { get; set; }
        public int? ReturnReason { get; set; }
        public int? PosOrGroupIdParent { get; set; }

        public virtual ICollection<AgeVerification> AgeVerification { get; set; }
        public virtual ICollection<ClientInfo> ClientInfo { get; set; }
        public virtual ICollection<KvitoEilute> KvitoEilute { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<PointsHeaders> PointsHeaders { get; set; }
        public virtual ICollection<Reward> Reward { get; set; }
        public virtual ICollection<SellDiscount> SellDiscount { get; set; }
        public virtual ICollection<SellEntry> SellEntry { get; set; }
    }
}
