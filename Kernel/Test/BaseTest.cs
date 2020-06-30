using Filuet.ASC.OnBoard.Kernel.Core;
using Filuet.Utils.Common.Business;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Filuet.ASC.OnBoard.Kernel.Test
{
    public abstract class BaseTest
    {
        public IAttendant GetAttendant() => new ServiceCollection().AddAttendant()
                .BuildServiceProvider()
                .GetRequiredService<IAttendant>();

        public CurrencyCode Currency = CurrencyCode.USDollar;

        public BaseTest()
        { }
    }
}
