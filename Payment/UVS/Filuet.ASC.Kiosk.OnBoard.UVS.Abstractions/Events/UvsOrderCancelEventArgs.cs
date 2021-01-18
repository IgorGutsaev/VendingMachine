using System;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Events
{
    public class UvsOrderCancelEventArgs : EventArgs
    {
        public bool Successed { get; set; }

        public string Message { get; set; }

        public static UvsOrderCancelEventArgs Create(bool successed, string message) => new UvsOrderCancelEventArgs { Successed = true, Message = message };
    }
}
