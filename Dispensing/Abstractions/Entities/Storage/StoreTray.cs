using Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Dispensing.Abstractions.Entities
{
    public abstract class StoreTray<T> : StoreUnit, IStoreTray<T>
        where T : IStoreBelt, new()
    {
        public IEnumerable<T> Belts { get => _belts; }

        //public TMachine Machine { get; set; }

        public T AddBelt(uint number)
        {
            T result = default;
            if (!_belts.Any() || !_belts.Any(x => x.Number == number))
            {
                result = new T();
                result.SetNumber(number);
                _belts.Add(result);
            }
            else if (_belts.Any(x => x.Number == number))
                throw new ArgumentException($"A belt with number {number} already exists!");

            return result;
        }

        private ICollection<T> _belts = new List<T>();

        public override string ToString() => $"{Number}/{Belts.Count()} belts"; //{Machine}/
    }
}