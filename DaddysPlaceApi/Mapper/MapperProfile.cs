using AutoMapper;
using DaddysPlaceApi.Entity;
using DaddysPlaceApi.ViewEntity;

namespace DaddysPlaceApi.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, UserViewEntity>().ReverseMap();
            CreateMap<ItemEntity, ItemViewEntity>().ReverseMap();
            CreateMap<BillEntity, BillViewEntity>().ReverseMap();
            CreateMap<OrderEntity, OrderViewEntity>().ReverseMap();
            CreateMap<PaymentEntity, PaymentViewEntity>().ReverseMap();
            CreateMap<ProductEntity, ProductViewEntity>().ReverseMap();
        }
    }
}
