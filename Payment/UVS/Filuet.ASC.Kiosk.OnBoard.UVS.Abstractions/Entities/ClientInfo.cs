using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class ClientInfo
    {
        public int Id { get; set; }
        public int HeadId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Vatcode { get; set; }
        public string Address { get; set; }
        public string Template { get; set; }

        public virtual KvitoGalva Head { get; set; }
    }
}
