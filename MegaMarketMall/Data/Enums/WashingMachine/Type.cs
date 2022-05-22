using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MegaMarketMall.Data.Enums.WashingMachine
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeWashingMachine
    {
        [EnumMember(Value="Автоматическая")]
        Automatic=1,
        [EnumMember(Value="Полуавтоматическая")]
        SemiAutomatic=2
    }
}