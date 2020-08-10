using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class EuroStages
    {
        public int Id { get; set; }
        public int PosId { get; set; }
        public int StageNr { get; set; }
        public DateTime When { get; set; }
    }
}
