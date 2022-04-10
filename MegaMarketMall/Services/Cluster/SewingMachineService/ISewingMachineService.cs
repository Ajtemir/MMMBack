using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Data.Interfaces.Get;
using MegaMarketMall.Dtos.Get.Cluster;
using MegaMarketMall.Dtos.Post;
using MegaMarketMall.Dtos.Put.Cluster;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.SewingMachines;

namespace MegaMarketMall.Services.Cluster.SewingMachineService
{
    public interface ISewingMachineService
    {
        Task<IQueryable<SewingMachine>> FilterAsync(IQueryable<SewingMachine> products, SewingMachineGet query);
        Task<SewingMachine> CreateAsync(SewingMachinePost data);
        Task<SewingMachine> GetByIdAsync(int id);
        Task UpdateAsync(int id, SewingMachinePut data);
    }
}