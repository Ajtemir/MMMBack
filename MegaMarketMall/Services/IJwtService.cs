using System.Threading.Tasks;
using MegaMarketMall.Dtos;
using MegaMarketMall.Models.Users;

namespace MegaMarketMall.Services
{
    public interface IJwtService
    {
        Task<AuthResponse> GetBothTokensAsync(User user, string ipAddress);
        Task<AuthResponse> GetRefreshTokenAsync(User user, string ipAddress);
        Task<bool> IsTokenValid(string accessToken, string ipAddress);
    }
}