using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Areas.Admin.ViewModels;
using MegaMarketMall.Context;
using MegaMarketMall.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Repositories.AdminRepository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationContext _context;
        private readonly IQueryable<Admin> _admins;

        public AdminRepository(ApplicationContext context)
        {
            _context = context;
            _admins = _context.Admins.Where(a => a.IsDeleted == false);
        }

        public async Task<List<Admin>> GetAllAsync()
        {
            var admins = await _admins.ToListAsync();
            return admins;
        }

        public async Task DeleteAsync(int id)
        {
            var currentAdmin = await _context.Admins.FirstOrDefaultAsync(a=>a.Id == id);
            currentAdmin.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(RegisterAdminViewModel model)
        {
            var admin = new Admin(model.Email, model.Password);
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
        }

        public async Task<Admin> GetByIdAsync(int id)
        {
            var admin = await _admins.FirstOrDefaultAsync(a => a.Id == id);
            return admin;
        }

       

        public async Task<bool> ConsistsAsync(string email)
        {
            var admin = await _context.Users.FirstOrDefaultAsync(a=>a.Email == email);
            return admin != null;
        }
    }
}