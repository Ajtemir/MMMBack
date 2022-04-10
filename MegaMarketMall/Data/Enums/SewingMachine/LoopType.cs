using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MegaMarketMall.Data.Enums.SewingMachine
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LoopType
    {
        [EnumMember(Value = "Автоматическая")]
        Automatic=1,
        [EnumMember(Value = "Полувтоматическая")]
        SemiAutomatic=2
    }
}