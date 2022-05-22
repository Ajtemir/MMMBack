using System.Collections.Generic;
using System.Threading.Tasks;
using MegaMarketMall.Models.Colors;

namespace MegaMarketMall.Services.ColorService
{
    public interface IColorService
    {
        Task<List<T>> GetColorsAsync<T>() where T : Color;

    }
}