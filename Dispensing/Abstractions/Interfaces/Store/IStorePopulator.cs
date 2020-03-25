using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces
{
    public interface IStorePopulator<TMachine, TTray, TBelt>
        where TMachine : IStoreMachine<TTray, TBelt>, new()
        where TTray : IStoreTray<TBelt>, new()
        where TBelt : IStoreBelt, new()
    {

        IStoreBuilder<TMachine, TTray, TBelt> AddTray(uint number);

        /// <summary>
        /// Creates belt and tray if not exists
        /// </summary>
        /// <param name="trayNumber"></param>
        /// <param name="beltNumber"></param>
        /// <returns></returns>
        IStoreBuilder<TMachine, TTray, TBelt> AddBelt(uint trayNumber, uint beltNumber);
    }
}
