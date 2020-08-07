using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Inkasac
    {
        public int Id { get; set; }
        public int IdOnPos { get; set; }
        public int Posid { get; set; }
        public DateTime OpTime { get; set; }
        public double Amount { get; set; }
        public int OpType { get; set; }
        public int Znr { get; set; }
        public int CashierId { get; set; }
        public string OpName { get; set; }
        public string ObjId { get; set; }
        public string ObjName { get; set; }
    }
}
