using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MegaMarketMall.Context;
using MegaMarketMall.Dtos.Get.Cluster;
using MegaMarketMall.Dtos.Post;
using MegaMarketMall.Dtos.Put.Cluster;
using MegaMarketMall.Models.Brands;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.SewingMachines;
using Microsoft.EntityFrameworkCore;
using SewingMachineBrand = MegaMarketMall.Models.ProductBrands.SewingMachineBrands.SewingMachineBrand;

namespace MegaMarketMall.Services.Cluster.SewingMachineService
{
    public class SewingMachineService:ISewingMachineService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _user;
        private readonly ApplicationContext _context;
        private readonly IProductPhotoService _photo; 

        public SewingMachineService(IMapper mapper, IUserService user, ApplicationContext context, IProductPhotoService photo)
        {
            _mapper = mapper;
            _user = user;
            _context = context;
            _photo = photo;
        }

        public IQueryable<SewingMachine> Filter(IQueryable<SewingMachine> products, SewingMachineGet query)
        {
            // var brandId = await _brand.GetBrandIdAsync(query.Brand);
            if (query.BrandId is not null)
                products = products.Where(p => p.BrandId == query.BrandId);
            if (query.TypeOfSewingMachine is not null)
                products = products.Where(p => p.TypeOfSewingMachine == query.TypeOfSewingMachine);
            if (query.LoopType is not null)
                products = products.Where(p => p.LoopType == query.LoopType);
            products = products.Include(p => p.Brand);
            return products;
        }

        public async Task<SewingMachine> CreateAsync(SewingMachinePost data)
        {
            var user = await _user.GetCurrentUserAsync();
            var product = _mapper.Map<SewingMachinePost, SewingMachine>(data);
            await _context.SewingMachines.AddAsync(product);
            await _context.SaveChangesAsync();
            await _photo.CreatePhotosAsync(data.Files, product.Id);
            return product;
        }

        public Task<SewingMachine> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(int id, SewingMachinePut data)
        {
            throw new System.NotImplementedException();
        }
    }
}