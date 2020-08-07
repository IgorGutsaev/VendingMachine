using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class KvitoEilute
    {
        public KvitoEilute()
        {
            InactivityTime = new HashSet<InactivityTime>();
            PointsItems = new HashSet<PointsItems>();
            PriceDiscountsItems = new HashSet<PriceDiscountsItem>();
        }

        public int Id { get; set; }
        public int GalvosId { get; set; }
        public int? PrekesKodas { get; set; }
        public double? Kiekis { get; set; }
        public double? Kaina { get; set; }
        public double? Suma { get; set; }
        public double? Mokesciai { get; set; }
        public double? Nuolaida { get; set; }
        public int? PrekesId { get; set; }
        public string Barkodas { get; set; }
        public double? VietDez { get; set; }
        public double? Savikaina { get; set; }
        public double? RealKaina { get; set; }
        public int? PriceOption { get; set; }
        public int? Vat { get; set; }
        public int? SellFlags { get; set; }
        public int? LineNumber { get; set; }
        public double? Duration { get; set; }
        public short? PriceType { get; set; }
        public string PriceOriginType { get; set; }
        public long? PriceIdentificator { get; set; }
        public string PackerId { get; set; }
        public double? MpvalueGranted { get; set; }
        public double? MpvaluePaid { get; set; }
        public string StrCode { get; set; }
        public int? ParentLineNo { get; set; }
        public int? OriginalLineNo { get; set; }

        public virtual KvitoGalva Galvos { get; set; }
        public virtual ICollection<InactivityTime> InactivityTime { get; set; }
        public virtual ICollection<PointsItems> PointsItems { get; set; }
        public virtual ICollection<PriceDiscountsItem> PriceDiscountsItems { get; set; }
    }
}
