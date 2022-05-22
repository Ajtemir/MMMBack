using System.Collections.Generic;
using System.Threading.Tasks;
using MegaMarketMall.Models.Users;

namespace MegaMarketMall.Repositories.UserRepository
{
    public interface IUserRepository<TEntity> where TEntity:User
    {
        
    }
}