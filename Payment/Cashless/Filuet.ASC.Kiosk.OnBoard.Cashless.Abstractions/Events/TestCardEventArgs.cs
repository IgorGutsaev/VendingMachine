using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Cashless.Abstractions.Events
{
    public enum TestResultError
    {
        [Description("No errors")]
        None = 0,
        [Description("Card reader error")]
        CardReaderError = 4
    }

    public class TestCardEventArgs : EventArgs
    {

        public TestResultError TestError { get; set; }

        public string Description { get; set; }

    }
}
