using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class SellEntry
    {
        public int Id { get; set; }
        public int GalvosId { get; set; }
        public int SellLine { get; set; }
        public int EntryCode { get; set; }
        public string Entry { get; set; }

        public virtual KvitoGalva Galvos { get; set; }
    }
}
