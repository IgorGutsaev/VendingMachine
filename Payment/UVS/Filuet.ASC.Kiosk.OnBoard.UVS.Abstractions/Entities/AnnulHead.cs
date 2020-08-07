using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class AnnulHead
    {
        public AnnulHead()
        {
            AnnulLine = new HashSet<AnnulLine>();
        }

        public int Id { get; set; }
        public int Posid { get; set; }
        public int IdOnPos { get; set; }
        public int CheckNr { get; set; }
        public int Znr { get; set; }
        public int CashierId { get; set; }
        public DateTime AnnulTime { get; set; }
        public int AnnulType { get; set; }

        public virtual ICollection<AnnulLine> AnnulLine { get; set; }
    }
}
