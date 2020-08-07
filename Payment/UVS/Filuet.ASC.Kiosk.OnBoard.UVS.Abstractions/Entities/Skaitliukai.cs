using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Skaitliukai
    {
        public int Id { get; set; }
        public int? AparatoId { get; set; }
        public int? Zetas { get; set; }
        public string Pistoletas { get; set; }
        public int? Benzinas { get; set; }
        public double? Skaitliukas { get; set; }
        public double? KiekisGryni { get; set; }
        public double? KiekisKort { get; set; }
        public double? KiekisTech { get; set; }
        public double? KiekisOver { get; set; }
        public int? Idz { get; set; }
        public short? PistNr { get; set; }
        public short? TankNr { get; set; }
    }
}
