using Filuet.ASC.Kiosk.OnBoard.Order.Abstractions.Enums;
using Filuet.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Filuet.ASC.Kiosk.OnBoard.Order.Abstractions.Converters
{
    public class GoodsObtainingMethodConverter : JsonConverter<GoodsObtainingMethod>
    {
        public override GoodsObtainingMethod Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => EnumHelper.GetValueFromCode<GoodsObtainingMethod>(reader.GetString());

        public override void Write(Utf8JsonWriter writer, GoodsObtainingMethod obtaining, JsonSerializerOptions options)
            => writer.WriteStringValue(obtaining.GetCode());
    }
}
