using System.Collections.Generic;
using System.Threading.Tasks;
using MegaMarketMall.Areas.Admin.ViewModels;
using MegaMarketMall.Models.Users;

namespace MegaMarketMall.Repositories.AdminRepository
{
    public interface IAdminRepository
    {
        Task<List<Admin>> GetAllAsync();
        Task DeleteAsync(int id);
        Task CreateAsync(RegisterAdminViewModel model);
        Task<Admin> GetByIdAsync(int id);
        Task<bool> ConsistsAsync(string email);

    }
}