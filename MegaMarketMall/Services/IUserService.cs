using System.Threading.Tasks;
using MegaMarketMall.Models.Products;
using MegaMarketMall.Models.Users;

namespace MegaMarketMall.Services
{
    public interface IUserService
    {
        Task<User> GetUserAsync();
        string GetEmailClaim();
        Task<bool> IsProductSellerAsync(Product product);

        Task<bool> CheckSellerByProductIdAsync(int id);
    }
}