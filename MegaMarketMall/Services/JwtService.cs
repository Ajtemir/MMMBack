using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Dtos;
using MegaMarketMall.Models.Tokens;
using MegaMarketMall.Models.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MegaMarketMall.Services
{
    public class JwtService : IJwtService
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _configuration;

        public JwtService(ApplicationContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<AuthResponse> GetBothTokensAsync(User user,string ipAddress)
        {
            string accessToken = GenerateAccessToken(user.Email,user.Role);
            string refreshToken = GenerateRefreshToken();
            return await SaveTokenDetails(ipAddress, refreshToken, accessToken, user.Id);
        }
        
        public async Task<AuthResponse> GetRefreshTokenAsync(User user,string ipAddress)
        {
            var refreshToken = GenerateRefreshToken();
            var accessToken = GenerateAccessToken(user.Email,user.Role);
            return await SaveTokenDetails(ipAddress, refreshToken:refreshToken, accessToken, user.Id);
        }
        
        public async Task<bool> IsTokenValid(string accessToken, string ipAddress)
        {
            var isValid = _context.UserRefreshTokens.FirstOrDefault
                (x => x.AccessToken == accessToken && x.IpAddress == ipAddress) != null;
            return await Task.FromResult(isValid);
        }
        
        private async Task<AuthResponse> SaveTokenDetails(string ipAddress, string refreshToken, string accessToken, int userId)
        {
            var userRefreshToken = new UserRefreshToken()
            {
                CreatedDate = DateTime.UtcNow,
                ExpirationDate = DateTime.UtcNow.AddMinutes(60),
                IpAddress = ipAddress,
                IsInvalidated = false,
                RefreshToken = refreshToken,
                AccessToken = accessToken,
                UserId = userId
            };
            await _context.UserRefreshTokens.AddAsync(userRefreshToken);
            await _context.SaveChangesAsync();
            return new AuthResponse{Token = accessToken, RefreshToken = refreshToken,IsSuccess = true};
        }

        private string GenerateAccessToken(string email, string role)
        {
            var jwtKey = _configuration.GetValue<string>("JwtSettings:Key");
            var keyBytes = Encoding.ASCII.GetBytes(jwtKey);
            var tokenHandler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(descriptor);
            string accessToken = tokenHandler.WriteToken(token);
            return accessToken;
        }
        
        private string GenerateRefreshToken()
        {
            var byteArray = new byte[64];
            using var cryptoProvider = new RNGCryptoServiceProvider();
            cryptoProvider.GetBytes(byteArray); 
            return Convert.ToBase64String(byteArray);
        }
    }
}