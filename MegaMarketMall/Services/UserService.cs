using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MegaMarketMall.Areas.Admin.ViewModels;
using MegaMarketMall.Context;
using MegaMarketMall.Data.Methods;
using MegaMarketMall.Models.Products;
using MegaMarketMall.Models.Users;
using MegaMarketMall.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationContext _context;
        private readonly IProductService _product;

        public UserService(IHttpContextAccessor httpContextAccessor, ApplicationContext context, IProductService product)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _product = product;
        }

        public string GetEmailClaim() => _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);
        
        public bool EmailClaimExists()
        {
            var email = GetEmailClaim();
            if (email is null)
                return false;
            return true;
        }
        
        public async Task<User> GetCurrentUserAsync()
        {
            var email = GetEmailClaim();
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.Email==email);
            return user;
        }

        public async Task<bool> IsProductSellerAsync(Product product)
        {
            User user = await GetCurrentUserAsync();
            if (user is null)
                return false;
            var seller = product.Seller;
            if (seller is null)
                return false;
            return seller.Id == user.Id;
        }

        public async Task<bool> ContainsEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.Email==email);
            return user != null;
        }

        public async Task CreateAdminAsync(AdminViewModel admin)
        {
            PasswordMethods.CreatePasswordHashSalt(admin.Password,out var passwordHash,out var passwordSalt);
            await _context.Admins.AddAsync(new Admin
            {
                Email = admin.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
                
            });
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckSellerByProductIdAsync(int productId)
        {
            User user = await GetCurrentUserAsync();
            if (user is null)
                return false;
            var product = await _product.GetByIdAsync(productId);
            if (product is null)
                return false;
            Console.WriteLine(product.SellerId);
            return user.Id == product.SellerId;
        }

        public async Task<User> GetUserByEmailAsync(string email)=>await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        private async Task<Product> GetProduct(int id) => await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }
}