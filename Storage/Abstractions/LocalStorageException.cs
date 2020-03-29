using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions
{
    public class LocalStorageException : Exception
    {
        public LocalStorageException(string message)
            : base(message) { }
    }
}
