using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Data.Interfaces.Get;
using MegaMarketMall.Dtos.Local.Product;
using MegaMarketMall.Dtos.Post;
using MegaMarketMall.Dtos.Put;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments.Conditioner;

namespace MegaMarketMall.Services
{
    public interface IConditionerService
    {
        Task<IQueryable<Conditioner>> FilterAsync(IQueryable<Conditioner> conditioners, IConditionerGet query);
        Task CreateAsync(ConditionerPost data);
        Task<Conditioner> GetByIdAsync(int id);
        Task UpdateAsync(int id, ConditionerPut data);
    }
}