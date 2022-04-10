using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MegaMarketMall.Data.Enums.SewingMachine
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeOfSewingMachine
    {
        [EnumMember(Value = "3-нитка")]
        ThreeThread=1,
        [EnumMember(Value = "4-нитка")]
        FourThread,
        [EnumMember(Value = "5-нитка")]
        FiveThread,
        [EnumMember(Value = "6-нитка")]
        SixThread,
        [EnumMember(Value = "Коверлок")]
        CoverLock,
        [EnumMember(Value = "Компьютерная")]
        Computer,
        [EnumMember(Value = "Механическая")]
        Mechanical,
        [EnumMember(Value = "Оверлок")]
        OverLock,
        [EnumMember(Value = "Распошивальная машина")]
        CoverStitch
        
    }
}