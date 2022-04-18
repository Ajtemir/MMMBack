using System.Collections.Generic;
using MegaMarketMall.Data.Interfaces.Product;

namespace MegaMarketMall.Dtos.Response.QueryResponse
{
    public class QueryResponse<TEntity> where TEntity:class,IEntity
    {
        public List<TEntity> Products { get; set; } = new();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}