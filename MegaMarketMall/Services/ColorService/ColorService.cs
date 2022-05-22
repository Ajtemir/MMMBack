using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Dtos.Response.BrandView;
using MegaMarketMall.Models.Brands;
using MegaMarketMall.Models.Colors;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Services.ColorService
{
    public class ColorService : IColorService
    {
        private readonly ApplicationContext _context;
        public ColorService(ApplicationContext context) =>_context = context;
        public async Task<List<T>> GetColorsAsync<T>() where T : Color => await _context.Set<T>().ToListAsync();
    }
}