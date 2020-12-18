using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.SDK.Jofemar.VisionEsPlus.Control
{
    public class ExtractCommand : ICommand
    {
        IDispenser _dispenser;
        IssueAddress _address;

        public ExtractCommand(IDispenser dispenser, IssueAddress address)
        {
            if (dispenser == null)
                throw new ArgumentException("Dispenser must be specified");

            if (address == null)
                throw new ArgumentException("Address is mandatory");

            _dispenser = dispenser;
            _address = address;
        }

        public void Execute()
        {
            _dispenser.Dispense(_address);
        }

        public void Undo()
        {
            throw new NotSupportedException("Can't undo excract");
        }
    }
}
