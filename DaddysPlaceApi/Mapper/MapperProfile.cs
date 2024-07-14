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
        }
    }
}
