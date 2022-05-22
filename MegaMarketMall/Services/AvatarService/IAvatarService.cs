using System.Threading.Tasks;
using MegaMarketMall.Data.Interfaces.Avatar;

namespace MegaMarketMall.Services.AvatarService
{
    public interface IAvatarService
    {
        Task<string> CreateAvatarAsync(IAvatar avatar);
    }
}