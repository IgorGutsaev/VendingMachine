using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class BarKodai
    {
        public int Id { get; set; }
        public int? PrekesKodas { get; set; }
        public string BarCode { get; set; }
        public int? Dep { get; set; }
    }
}
