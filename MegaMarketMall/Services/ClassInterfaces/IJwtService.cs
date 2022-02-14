using System.Threading.Tasks;
using MegaMarketMall.Models.Dto;

namespace MegaMarketMall.Services.ClassInterfaces
{
    public interface IJwtService
    {
        Task<AuthResponse> GetTokenAsync(AuthUserDto authRequest, string ipAddress);
        Task<AuthResponse> GetRefreshTokenAsync(string ipAddress,int userId, string userName);
        Task<bool> IsTokenValid(string accessToken, string ipAddress);
    }
}