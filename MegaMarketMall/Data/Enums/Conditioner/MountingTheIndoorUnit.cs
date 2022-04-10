using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MegaMarketMall.Data.Enums.Conditioner
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MountingTheIndoorUnit
    {
        [EnumMember(Value = "Канальный")]
        Channel=1,
        [EnumMember(Value = "Кассетный")]
        Cassette,
        [EnumMember(Value = "Колонный")]
        Column,
        [EnumMember(Value = "Напольно-Патолочный")]
        FloorCeiling,
        [EnumMember(Value = "Напольный")]
        Floor,
        [EnumMember(Value = "Настенный")]
        WallMounted,
        [EnumMember(Value = "Потолочный")]
        Ceiling


        
        
    }
}