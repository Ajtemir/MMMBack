using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Dtos.Response.BrandView;
using MegaMarketMall.Models.Brands;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Services.BrandService
{
    public class BrandService : IBrandService
    {
        private readonly ApplicationContext _context;

        public BrandService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<BrandView>> GetBrandAsync<T>() where T:Brand
        {
            return await _context.Set<T>().Select(p => new BrandView
            {
                Id = p.Id,
                Name = p.Name
            }).ToListAsync();
        }
        
    }
}