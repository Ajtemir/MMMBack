using MegaMarketMall.Data.Interfaces.Product;

namespace MegaMarketMall.Data.Abstracts
{
    public abstract class BaseProductPut : IProductCore
    {
        public uint? Price { get; set; }
        public string Description { get; set; }
        public bool? IsDelivered { get; set; }
    }
}