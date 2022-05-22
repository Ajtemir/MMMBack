using MegaMarketMall.Models.Colors;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Context
{
    public partial class ApplicationContext
    {
        
        public DbSet<Color> Colors { get; set; }
        public DbSet<WristWatchColor> WristWatchColors { get; set; }
    }
}