using System.Collections.Generic;

namespace MegaMarketMall.Dtos.Response.ProductView
{
    public class ProductViewResponse
    {
        public List<ProductView> Products { get; set; } = new();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}