using MegaMarketMall.Data.Interfaces.Get;

namespace MegaMarketMall.Dtos.Get
{
    public class ProductGet : IPage
    {
        public uint? FromPrice { get; set; } = null;
        public uint? ToPrice { get; set; } = null;
        public string Text { get; set; } = null;
        public string SortBy { get; set; } = null;
        public int? Page { get; set; } = 1;
        public bool? Deliver { get; set; } = null;
    }
}