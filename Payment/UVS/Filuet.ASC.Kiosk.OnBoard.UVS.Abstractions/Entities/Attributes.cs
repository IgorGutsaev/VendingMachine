using System;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Entities
{
    public partial class Attributes
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public short MinCharCount { get; set; }
        public short MaxCharCount { get; set; }
        public byte ValueFormat { get; set; }
        public string PossibleValues { get; set; }
        public bool IsRequired { get; set; }
        public bool IsPrintable { get; set; }
        public bool IsVisible { get; set; }
        public byte PrintFormat { get; set; }
        public byte Deleted { get; set; }
        public byte[] Timestamp { get; set; }
        public int Order { get; set; }
    }
}
