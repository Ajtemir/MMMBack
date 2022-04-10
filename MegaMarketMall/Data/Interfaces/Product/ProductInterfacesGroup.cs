namespace MegaMarketMall.Data.Interfaces.Product
{
    public interface IProductCore:IPrice,IDescription,IDeliver{}

    public interface IEntity:IProductCore,ITimeStamp,IProductPhoto{}
}