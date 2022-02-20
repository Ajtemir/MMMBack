using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Models.Products;
using MegaMarketMall.Models.Users;

namespace MegaMarketMall.Models.Relations
{
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public bool IsViewed { get; set; } = false;
        public bool IsFavorite { get; set; } = false;
    }
}