using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Common.Abstractions
{
    public class RemoteController
    {
        private ICommand _command;

        public void SetCommand(ICommand com) { _command = com; }

        public void Execute() => _command.Execute();

        public void Undo() => _command.Undo();
    }
}
