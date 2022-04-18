using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Dtos.Post;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.WashingMachines;

namespace MegaMarketMall.Services
{
    public interface IWashingMachineService
    {
        public IQueryable<WashingMachine> Filter(IQueryable<WashingMachine> products, WashingMachineGet query);
        public Task CreateAsync(WashingMachinePost data);
    }
}