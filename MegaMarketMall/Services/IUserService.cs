using System.Threading.Tasks;
using MegaMarketMall.Areas.Admin.ViewModels;
using MegaMarketMall.Models.Products;
using MegaMarketMall.Models.Users;

namespace MegaMarketMall.Services
{
    public interface IUserService
    {
        Task<User> GetCurrentUserAsync();
        string GetEmailClaim();
        Task<bool> IsProductSellerAsync(Product product);
        Task<bool> ContainsEmailAsync(string email);
        Task CreateAdminAsync(AdminViewModel admin);
        Task<bool> CheckSellerByProductIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);

    }
}