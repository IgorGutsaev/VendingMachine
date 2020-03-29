using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions
{
    public interface IIdentifiable<T>
    {
        T Id { get; }
    }
}
