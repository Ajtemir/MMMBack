using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MegaMarketMall.Data.Enums.Conditioner
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RecommendedAreaSquareMeter
    {
        [EnumMember(Value = "Больше 50")]
        More50=1,
        [EnumMember(Value = "До 20")]
        UpTo20,
        [EnumMember(Value = "До 25")]
        UpTo25,
        [EnumMember(Value = "До 30")]
        UpTo30,
        [EnumMember(Value = "До 35")]
        Upto35,
        [EnumMember(Value = "До 40")]
        UpTo40,
        [EnumMember(Value = "До 45")]
        UpTo45,
        [EnumMember(Value = "До 50")]
        UpTo50
    }
}