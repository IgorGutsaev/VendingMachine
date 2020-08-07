using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Mokesciai
    {
        public int Id { get; set; }
        public int MokescioKodas { get; set; }
        public string MokescioPavadinimas { get; set; }
        public double MokescioDydis { get; set; }
        public int MokescioPrioritetas { get; set; }
    }
}
