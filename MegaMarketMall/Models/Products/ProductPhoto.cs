using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMarketMall.Models.Products
{
    public class ProductPhoto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}