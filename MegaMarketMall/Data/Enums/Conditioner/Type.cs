using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MegaMarketMall.Data.Enums.Conditioner
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeConditioner
    {
        [EnumMember(Value="Внешний блок")]
        OutBlock=1,
        [EnumMember(Value="Внутренний блок")]
        InnerBlock=2,
        [EnumMember(Value="Моноблок")]
        MonoBlock=3,
        [EnumMember(Value="Мультисплит-система")]
        MultiSplitSystem=4,
        [EnumMember(Value="Сплит-система")]
        SplitSystem=5
    }
}