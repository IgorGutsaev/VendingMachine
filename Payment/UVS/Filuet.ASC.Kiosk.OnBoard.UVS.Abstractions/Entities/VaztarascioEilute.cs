using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class VaztarascioEilute
    {
        public int Id { get; set; }
        public int? VaztarascioId { get; set; }
        public int? PrekesKodas { get; set; }
        public int? PrekesId { get; set; }
        public double? Kiekis { get; set; }
        public double? GavimoKaina { get; set; }
        public int? GavimoForma { get; set; }
        public double? PardavimoKaina { get; set; }
        public double? GavimoSuma { get; set; }
    }
}
