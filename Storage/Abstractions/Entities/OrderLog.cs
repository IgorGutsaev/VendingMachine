using System;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions
{
    [Serializable]
    public class OrderLog : IdentifiableEntity<string>
    {
        public string  Number { get; private set; }

        public string Action { get; private set; }

        public string Data { get; private set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        protected OrderLog()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number">Unique key</param>
        /// <param name="action">see OrderAction entity</param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static OrderLog Create(string number, string action, string data)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Order number is mandatory");

            if (string.IsNullOrWhiteSpace(action))
                throw new ArgumentException("Order action is mandatory");

            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentException("Order action data is mandatory");

            return new OrderLog { Id = Guid.NewGuid().ToString(), Number = number.Trim(), Action = action.Trim(), Data = data.Trim() };
        }
    }
}
