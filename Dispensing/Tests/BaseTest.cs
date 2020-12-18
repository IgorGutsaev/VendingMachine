using Microsoft.Extensions.DependencyInjection;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Core;
using System;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Tests.Entities;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Tests
{
    public abstract class BaseTest
    {
        public ILayout BuildLayout(Action<ILayoutBuilder> builderAction, Func<ILayout, bool> validateAction = null)
            => new ServiceCollection().AddLayoutBuilder<BarStoreTray, BazStoreBelt>(builderAction)
                .BuildServiceProvider()
                .GetRequiredService<ILayoutBuilder>().Build(validateAction);

        public BaseTest()
        { }
    }
}
