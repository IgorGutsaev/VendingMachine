using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Cashbox.Abstractions
{
    public enum TestResultError
    {
        [Description("No errors")]
        None = 0,
        [Description("Bill receiver error")]
        BillReceiverError = 4,
        [Description("Coin acceptor error")]
        CoinAcceptorError = 8
    }

    public struct TestResultCash
    {
        public string Description { get; set; }

        public TestResultError Result { get; set; }
    }
}
