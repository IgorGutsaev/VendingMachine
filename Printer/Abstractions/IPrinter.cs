using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Printer.Abstractions
{
    public interface IPrinter
    {
        void TestPrint(string message);

        void Print(string message);

        void Reset();

        string Status();
    }
}
