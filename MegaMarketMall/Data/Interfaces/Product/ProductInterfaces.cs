using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Models.Products;
using Newtonsoft.Json;

namespace MegaMarketMall.Data.Interfaces.Product
{
    public interface IProductId
    {
        public int Id { get; set; }
    }

    public interface ISellerId
    {
        public int SellerId { get; set; }
    }

    public interface ICategoryId
    {
        public int CategoryId { get; set; }
    }

    public interface ITimeStamp
    {
        public DateTime TimeStamp { get; set; }
    }

    public interface IUpdatedTime
    {
        public int UpdatedTime { get; set; }
    }

    public interface IProductPhoto
    {
        List<ProductPhoto> Photos { get; set; }
    }

    public interface IPrice
    {
        uint? Price { get; set; }
    }

    public interface IDescription
    {
        string Description { get; set; }
    }

    public interface IDeliver
    {
        bool? IsDelivered { get; set; }
    }
    
    public interface IBrandFk
    {
        public int? BrandId { get; set; }
       

    }
}