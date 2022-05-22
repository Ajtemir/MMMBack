using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MegaMarketMall.Context;
using MegaMarketMall.Data.Extensions;
using MegaMarketMall.Data.Extensions.Cluster;
using MegaMarketMall.Data.Interfaces.Get;
using MegaMarketMall.Dtos.Post;
using MegaMarketMall.Dtos.Put;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments.Conditioner;
using MegaMarketMall.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Services
{
    public class ConditionerService : IConditionerService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IProductPhotoService _photos;
        private readonly IUserService _user;
        private readonly IRepository<Conditioner> _repository;



        public ConditionerService(ApplicationContext context, IMapper mapper, IProductPhotoService photos, IUserService user, IRepository<Conditioner> repository)
        {
            _context = context;
            _mapper = mapper;
            _photos = photos;
            _user = user;
            _repository = repository;
        }

        public IQueryable<Conditioner> Filter(IQueryable<Conditioner> conditioners,IConditionerGet query)
        {
            if (query.BrandId is not null)
            {
                // var brand = await GetBrandByNameAsync(query.Brand);
                conditioners=conditioners.Where(b => b.Id == query.BrandId);
            }
            if (query.Type != null)
                conditioners = conditioners.Where(c=>c.Type==query.Type);
            if (query.RecommendedArea!=null)
                conditioners = conditioners.Where(c => c.RecommendedArea == query.RecommendedArea);
            if (query.TypeCompressor!=null)
                conditioners = conditioners.Where(c => c.TypeCompressor == query.TypeCompressor);
            if (query.MountingTheIndoorUnit != null)
                conditioners = conditioners.Where(c => c.MountingTheIndoorUnit == query.MountingTheIndoorUnit);
            conditioners = conditioners.Include(c => c.Brand);
            return conditioners;
        }

        public async Task CreateAsync(ConditionerPost data)
        {
            var user = await _user.GetCurrentUserAsync();
            var conditioner = _mapper.Map<ConditionerPost, Conditioner>(data);
            //TODO recoment
            // conditioner.SellerId = user.Id;
            conditioner.SellerId = 2;
            await _context.Conditioners.AddAsync(conditioner);
            await _context.SaveChangesAsync();
            await _photos.CreatePhotosAsync(data.Files, conditioner.Id);
        }

        public async Task<Conditioner> GetByIdAsync(int id)
        {
            var conditioner = await _context.Conditioners.Include(c=>c.Photos).FirstOrDefaultAsync(c=>c.Id==id);
            return conditioner;
        }

        public async Task UpdateAsync(int id, ConditionerPut data)
        {
            var conditioner = await GetByIdAsync(id);
            conditioner.MapProductPutData(data);
            await _repository.DeletePhotos(conditioner, data);
            // await _brand.MapBrandAsync(conditioner, data.Brand);
            conditioner.MapAdditionalPutData(data);
            await _context.SaveChangesAsync();
        }


        // private async Task<ConditionerBrand> GetBrandByNameAsync(string name)
        //     => await _context.ConditionerBrands
        //         .FirstOrDefaultAsync(b=>b.Name.Equals(name));
    }
}
