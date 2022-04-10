using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MegaMarketMall.Context;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Dtos.Post;
using MegaMarketMall.Models.Brands;
using MegaMarketMall.Models.ProductBrands.WashingMachineBrands;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.WashingMachines;
using MegaMarketMall.Repository;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Services
{
    public class WashingMachineService : IWashingMachineService
    {
        private readonly IBrandRepository<Brand, WashingMachine> _brand;
        private readonly IUserService _user;
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        private readonly IProductPhotoService _photo;

        public WashingMachineService(IBrandRepository<Brand, WashingMachine> brand, IUserService user, IMapper mapper, ApplicationContext context, IProductPhotoService photo)
        {
            _brand = brand;
            _user = user;
            _mapper = mapper;
            _context = context;
            _photo = photo;
        }

        public async Task<IQueryable<WashingMachine>> FilterAsync(IQueryable<WashingMachine> products, WashingMachineGet query)
        {
            if (query.BrandId != null)
            {
                products=products.Where(b => b.Id == query.BrandId);
            }
            if (query.Size is not null)
                products = products.Where(p => Equals(p.Size, query.Size));
            if (query.Type is not null)
                products = products.Where(p => p.Size.Equals(query.Size));
            if (query.DownloadType is not null)
                products = products.Where(p => p.DownloadType==query.DownloadType);
            products = products.Include(c => c.Brand);
            return products;
        }

        public async Task CreateAsync(WashingMachinePost data)
        {
            var user = await _user.GetUserAsync();
            var product = _mapper.Map<WashingMachinePost, WashingMachine>(data);
            product.SellerId = user.Id;
            await _context.WashingMachines.AddAsync(product);
            await _context.SaveChangesAsync();
            await _photo.CreatePhotosAsync(data.Files, product.Id);
        }
    }
}