using System.Collections.Generic;

namespace MegaMarketMall.Data.Interfaces.Brand
{
    public interface IBrandId
    {
        public int Id { get; set; }
    }

    public interface IBrandName
    {
        public string Name { get; set; }
    }

    

    public interface IBrandFKey
    {
        public int? BrandId { get; set; }
    }
    
    public interface IProductsOfBrand<T>
    {
        public List<T> Products { get; set; }
    }

    public interface IProductBrandPut
    {
        public int BrandId { get; set; }
    }

    // public interface IBrandGet
    // {
    //     public string Brand { get; set; }
    // }
    //
    // public interface IBrand<T>
    // {
    //     public T Brand { get; set; }
    // }
}