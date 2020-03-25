using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities
{
    /// <summary>
    /// Unit selling machine (dispensing locker)
    /// </summary>
    /// <typeparam name="TTray"></typeparam>
    /// <typeparam name="TBelt"></typeparam>
    public abstract class StoreMachine<TTray, TBelt> : StoreUnit, IStoreMachine<TTray, TBelt>
        where TTray : IStoreTray<TBelt>, new()
        where TBelt : IStoreBelt, new()
    {
        public IEnumerable<TTray> Trays { get => _trays; } 

        public TTray AddTray(uint number)
        {
            TTray result = default;

            if (!_trays.Any() || !_trays.Any(x => x.Number == number))
            {
                result = new TTray();
                result.SetNumber(number);
                _trays.Add(result);
            }
            else if (_trays.Any(x => x.Number == number))
                throw new ArgumentException($"A belt with number {number} already exists!");

            return result;
        }

        private ICollection<TTray> _trays = new List<TTray>();

        public override string ToString() => $"{Number}/{Trays.Count()} trays";
    }
}