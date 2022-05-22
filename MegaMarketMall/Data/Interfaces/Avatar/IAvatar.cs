using Microsoft.AspNetCore.Http;

namespace MegaMarketMall.Data.Interfaces.Avatar
{
    public interface IAvatar
    {
        public IFormFile Avatar { get; set; }
    }
}