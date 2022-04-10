using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MegaMarketMall.Data.Enums.Conditioner
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CompressorType
    {
        [EnumMember(Value = "Инверторный")]
        Inverter=1,
        [EnumMember(Value = "Классический")]
        Classic
    }
}