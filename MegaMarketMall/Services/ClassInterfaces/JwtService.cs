using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Models;
using MegaMarketMall.Models.Dto;
using Microsoft.Extensions.Configuration;

namespace MegaMarketMall.Services.ClassInterfaces
{
    public class JwtService : IJwtService
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration, ApplicationContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        
        public async Task<AuthResponse> GetTokenAsync(AuthUserDto authRequest, string ipAddress)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email.Equals(authRequest.Email));
            if (user is null)
                return await Task.FromResult<AuthResponse>(null);
            var tokenString = GenerateToken(user.UserName);
            string refreshToken = GenerateRefreshToken();
            return await SaveTokenDetails(ipAddress, refreshToken, tokenString, user.UserId);
        }
    }
}