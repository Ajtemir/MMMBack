using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Data.Constants;
using MegaMarketMall.Models;
using MegaMarketMall.TestData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MegaMarketMall
{
    public static class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();


        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}