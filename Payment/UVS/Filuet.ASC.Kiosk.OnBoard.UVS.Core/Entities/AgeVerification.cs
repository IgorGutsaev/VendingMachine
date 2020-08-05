namespace Filuet.ASC.Kiosk.OnBoard.UVS.Core.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class AgeVerification
    {
        public int Id { get; set; }
        public int GalvosId { get; set; }
        public string BDate { get; set; }
        public bool Maturity { get; set; }
    
        public virtual KvitoGalva KvitoGalva { get; set; }
    }
}
