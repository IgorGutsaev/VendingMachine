using Filuet.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Storage.Abstractions
{
    [Serializable]
    public class Planogram : IdentifiableEntity<string>
    {
        public string Data { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        protected Planogram()
        {
            Id = Guid.NewGuid().ToString();
        }

        public static Planogram Create(string data = "", DateTime? timestamp = null)
        {
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentException("Unable to save empty planogram");
            if (data.IsValidJson())
                throw new ArgumentException("Planogram must be in json format");

            return new Planogram { Data = data.Trim(), Timestamp = timestamp.HasValue ? timestamp.Value : DateTime.UtcNow };
        }
    }
}
