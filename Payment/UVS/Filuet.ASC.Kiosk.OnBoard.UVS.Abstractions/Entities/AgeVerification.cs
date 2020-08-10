using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class AgeVerification
    {
        public int Id { get; set; }
        public int GalvosId { get; set; }
        public string Bdate { get; set; }
        public bool Maturity { get; set; }

        public virtual KvitoGalva Galvos { get; set; }
    }
}
