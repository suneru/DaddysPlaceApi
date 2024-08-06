using AutoMapper;
using DaddysPlaceApi.Entity;
using DaddysPlaceApi.Entity.AllEntity;
using DaddysPlaceApi.ViewEntity;
using DaddysPlaceApi.ViewEntity.AllViewEntity;
namespace DaddysPlaceApi.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, UserViewEntity>().ReverseMap();
            CreateMap<UsereditEntity, UserVEditEntity>().ReverseMap();
            CreateMap<UserEditRoleEntity, UserEditVRoleEntity>().ReverseMap();
            CreateMap<ItemEntity, ItemViewEntity>().ReverseMap();
            CreateMap<BillEntity, BillViewEntity>().ReverseMap();
            CreateMap<OrderEntity, OrderViewEntity>().ReverseMap();
            CreateMap<PaymentEntity, PaymentViewEntity>().ReverseMap();
            CreateMap<ProductEntity, ProductViewEntity>().ReverseMap();
            CreateMap<AllProductEntity, AllProductViewEntity>().ReverseMap();
            CreateMap<CategoryEntity, CategoryViewEntity>().ReverseMap();
        }
    }
}
