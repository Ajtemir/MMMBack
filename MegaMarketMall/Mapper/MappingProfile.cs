using AutoMapper;
using MegaMarketMall.Dtos.Post;
using MegaMarketMall.Dtos.Put.Cluster;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments.Conditioner;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.SewingMachines;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.WashingMachines;
using MegaMarketMall.TestData;

namespace MegaMarketMall.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<ConditionerPost, Conditioner>();
            CreateMap<WashingMachinePost, WashingMachine>();
            CreateMap<SewingMachinePost, SewingMachine>();
            CreateMap<SewingMachinePut,SewingMachine>();
            //TODO TEST
            CreateMap<MapObject, MapObjectTo>();
        }
    }

   
}