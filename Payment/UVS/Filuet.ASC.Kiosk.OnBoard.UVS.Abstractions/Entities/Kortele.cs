using System;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{    
    public partial class Kortele
    {
        public string Id_number { get; set; }
        public short? CardType { get; set; }
        public short? CardSubType { get; set; }
        public string Benzinas { get; set; }
        public double? Bendras_limitas { get; set; }
        public double? Limitas_dienai { get; set; }
        public double? Limitas_menesiui { get; set; }
        public int Savininkas { get; set; }
        public int? Naudotojas { get; set; }
        public double? Kiekis { get; set; }
        public double? PrevKiekis { get; set; }
        public int? Statusas { get; set; }
        public DateTime? Updated { get; set; }
        public bool PasiustaICardlista { get; set; }
        public string Key1B { get; set; }
        public string PusePIN { get; set; }
        public double? MenesioLikutis { get; set; }
        public int? Menuo { get; set; }
        public short? BlokavimoPriezastis { get; set; }
        public double? PrevMenesioLikutis { get; set; }
        public bool SektiMenesioLimita { get; set; }
        public bool SektiBendraLimita { get; set; }
        public bool MK_MagneticCard { get; set; }
        public bool MK_JudintaDabar { get; set; }
        public DateTime? Redaguota { get; set; }
        public byte[] Aparatai { get; set; }
        public byte[] C_Aparatai { get; set; }
        public int ID { get; set; }
        public string GroupId { get; set; }
    }
}
