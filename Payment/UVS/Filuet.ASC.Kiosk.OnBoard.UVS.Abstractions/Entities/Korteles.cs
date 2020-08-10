using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Korteles
    {
        public string IdNumber { get; set; }
        public short? CardType { get; set; }
        public short? CardSubType { get; set; }
        public string Benzinas { get; set; }
        public double? BendrasLimitas { get; set; }
        public double? LimitasDienai { get; set; }
        public double? LimitasMenesiui { get; set; }
        public int Savininkas { get; set; }
        public int? Naudotojas { get; set; }
        public double? Kiekis { get; set; }
        public double? PrevKiekis { get; set; }
        public int? Statusas { get; set; }
        public DateTime? Updated { get; set; }
        public bool PasiustaIcardlista { get; set; }
        public string Key1B { get; set; }
        public string PusePin { get; set; }
        public double? MenesioLikutis { get; set; }
        public int? Menuo { get; set; }
        public short? BlokavimoPriezastis { get; set; }
        public double? PrevMenesioLikutis { get; set; }
        public bool SektiMenesioLimita { get; set; }
        public bool SektiBendraLimita { get; set; }
        public bool MkMagneticCard { get; set; }
        public bool MkJudintaDabar { get; set; }
        public DateTime? Redaguota { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] Aparatai1 { get; set; }
        public int Id { get; set; }
        public string GroupId { get; set; }
    }
}
