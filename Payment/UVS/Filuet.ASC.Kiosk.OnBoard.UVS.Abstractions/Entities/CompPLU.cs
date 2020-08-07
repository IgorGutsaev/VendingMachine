using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class CompPlu
    {
        public int Id { get; set; }
        public int Dep { get; set; }
        public int MainCode { get; set; }
        public string SupCode { get; set; }
        public double Coef { get; set; }
        public int SupType { get; set; }
    }
}
