using System.Collections.Generic;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Repositories.UserRepository
{
    public class UserRepository<TEntity> : IUserRepository<TEntity> where TEntity:User
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        
    }
}