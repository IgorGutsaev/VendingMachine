using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class StartParam
    {
        public int Id { get; set; }
        public int ApId { get; set; }
        public int Znr { get; set; }
        public int KvNr { get; set; }
        public bool? Valid { get; set; }
        public bool? Continue { get; set; }
    }
}
