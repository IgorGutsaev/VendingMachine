using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Common.Abstractions
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
