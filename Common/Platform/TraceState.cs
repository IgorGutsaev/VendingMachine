using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Common.Platform
{
    public class TraceState
    {
        public static TraceState State { get; private set; }

        static TraceState() { State = new TraceState(); }

        private TraceState() { }

        public string OrderNumber { get; private set; }

        public static void FlushOrderNumber()
        {
            State.OrderNumber = string.Empty;
        }

        public static void SetOrderNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("The order number in trace state must be specified");

            State.OrderNumber = number;
        }
    }
}
