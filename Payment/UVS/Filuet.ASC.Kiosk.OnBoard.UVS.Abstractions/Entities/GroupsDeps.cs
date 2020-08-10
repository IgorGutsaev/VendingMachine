using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class GroupsDeps
    {
        public int Id { get; set; }
        public string Plugroup { get; set; }
        public string Dep { get; set; }
        public string Pav { get; set; }
        public bool DoNotSendToScales { get; set; }
    }
}
