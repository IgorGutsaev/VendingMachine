using Microsoft.Extensions.DependencyInjection;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using Filuet.ASC.Kiosk.OnBoard.Dispensing.Tests.Entities;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Tests
{
    public abstract class BaseTest
    {
        public IStoreMachine<BarStoreTray, BazStoreBelt> GetMachine<TTray, TBelt>(Action<IStorePopulator<FooStoreMachine, BarStoreTray, BazStoreBelt>> builderAction, Func<IStoreMachine<BarStoreTray, BazStoreBelt>, bool> validateAction = null)
            => new ServiceCollection().AddMachineBuilder(builderAction)
                .BuildServiceProvider()
                .GetRequiredService<IStoreBuilder<FooStoreMachine, BarStoreTray, BazStoreBelt>>().Build(validateAction);

        public BaseTest()
        { }
    }
}
