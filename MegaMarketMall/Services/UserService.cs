using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using MegaMarketMall.Context;
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
        
        public async Task<User> GetUserAsync()
        {
            var email = GetEmailClaim();
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.Email==email);
            return user;
        }

        public async Task<bool> IsProductSellerAsync(Product product)
        {
            User user = await GetUserAsync();
            if (user is null)
                return false;
            var seller = product.Seller;
            if (seller is null)
                return false;
            return seller.Id == user.Id;
        }

        public async Task<bool> CheckSellerByProductIdAsync(int productId)
        {
            User user = await GetUserAsync();
            if (user is null)
                return false;
            var product = await _product.GetByIdAsync(productId);
            if (product is null)
                return false;
            Console.WriteLine(user.Id);
            Console.WriteLine(product.SellerId);
            return user.Id == product.SellerId;
        }

        private async Task<Product> GetProduct(int id) => await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }
}