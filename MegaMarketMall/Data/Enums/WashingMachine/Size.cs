using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MegaMarketMall.Data.Enums.WashingMachine
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Size
    {
        [EnumMember(Value="Полногабаритная(48-65 см)")]
        FullSize=1,
        [EnumMember(Value = "Узкая(32-47 см)")]
        Narrow=2
    }
}
