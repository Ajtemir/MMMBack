using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MegaMarketMall.Data.Enums.WashingMachine
{
    [JsonConverter(typeof(StringEnumConverter))]   
    public enum DownloadType
    {
        [EnumMember(Value = "Вертикальная")]
        Vertical=1,
        [EnumMember(Value = "Горизонтальная")]
        Horizontal=2
    }
}