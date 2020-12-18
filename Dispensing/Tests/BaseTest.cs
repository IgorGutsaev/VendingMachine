using Microsoft.Extensions.DependencyInjection;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Core;
using System;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Tests.Entities;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Tests
{
    public abstract class BaseTest
    {
        public ILayout BuildLayout(Action<ILayoutBuilder<BarStoreTray, BazStoreBelt>> builderAction, Func<ILayout, bool> validateAction = null)
            => new ServiceCollection().AddLayoutBuilder(builderAction)
                .BuildServiceProvider()
                .GetRequiredService<ILayoutBuilder<BarStoreTray, BazStoreBelt>>().Build(validateAction);

        public BaseTest()
        { }
    }
}
