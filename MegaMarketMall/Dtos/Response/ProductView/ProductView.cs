using System.Collections.Generic;

namespace MegaMarketMall.Dtos.Response.ProductView
{
    public class ProductView
    {
        public int  Id { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; } = null;
        public int Views { get; set; } = default;
        public int Favorites { get; set; } = default;
        public List<string> Photos { get; set; }
        public CategoryView Category { get; set; }
        public SellerView Seller { get; set; }
    }
}