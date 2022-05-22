using System.Collections.Generic;
using MegaMarketMall.Models.Products.Cluster.PersonalItems.Accessories.WristWatches;
using Newtonsoft.Json;

namespace MegaMarketMall.Models.Colors
{
    public class WristWatchColor : Color
    {
        [JsonIgnore] public virtual List<WristWatch> WristWatches { get; set; } = new();
    }
}