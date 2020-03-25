using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces
{
    public interface IStoreBuilder<TMachine, TTray, TBelt> : IStorePopulator<TMachine, TTray, TBelt>
        where TMachine : IStoreMachine<TTray, TBelt>, new()
        where TTray : IStoreTray<TBelt>, new()
        where TBelt : IStoreBelt, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validate">Manufacturer dependend validation (number of machines/trays/belts etc.)</param>
        /// <returns></returns>
        TMachine Build(Func<TMachine, bool> validate = null);
    }
}
