using MegaMarketMall.Models.Products;
using MegaMarketMall.Models.Users;

namespace MegaMarketMall.Models.Relations
{
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public bool IsFavorite { get; set; }
    }
}