using Filuet.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.OnBoard.Kernel.Core.Events
{
    public class AttendantStateEventArgs : EventArgs
    {
        public AttendantState PreviousState { get; set; }

        public AttendantState State { get; set; }

        public override string ToString() => $"State changed: {PreviousState.GetDescription()} -> {State.GetDescription()}";
    }
}
