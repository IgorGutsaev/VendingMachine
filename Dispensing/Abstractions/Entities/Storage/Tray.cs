using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities
{
    public abstract class Tray : LayoutUnit, ITray
    {
        public IEnumerable<IBelt> Belts { get => _belts; }

        public IBelt AddBelt<TBelt>(uint number)
            where TBelt : Belt, new()
        {
            IBelt result = default;
            if (!_belts.Any() || !_belts.Any(x => x.Number == number))
            {
                result = new TBelt();
                result.SetNumber(number);
                _belts.Add(result);
            }
            else if (_belts.Any(x => x.Number == number))
                throw new ArgumentException($"A belt with number {number} already exists!");

            return result;
        }

        private ICollection<IBelt> _belts = new List<IBelt>();

        public override string ToString() => $"Tray {Number} consists of {Belts.Count()} belts"; //{Machine}/
    }
}