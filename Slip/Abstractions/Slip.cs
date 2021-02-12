using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.SlipAbstractions
{
    public class Slip
    {
        public string Data { get; set; }

        public static Slip Create(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentException("Slip data must be specified");

            return new Slip { Data = data.Trim() };
        }

        public override string ToString() => Data.Trim();
    }
}
