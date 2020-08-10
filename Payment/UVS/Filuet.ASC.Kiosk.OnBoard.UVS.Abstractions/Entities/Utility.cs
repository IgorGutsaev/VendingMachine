using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Utility
    {
        public int Id { get; set; }
        public int Dep { get; set; }
        public int KasosNr { get; set; }
        public int Kasininkas { get; set; }
        public int GalvosId { get; set; }
        public int KvitoNr { get; set; }
        public double Suma { get; set; }
        public string ServiceBarcode { get; set; }
        public string GoodsBarcode { get; set; }
        public DateTime Laikas { get; set; }
        public int? EilNr { get; set; }
    }
}
