using AutoMapper;
using DbcWebApi.Entities;
using DbcWebApi.Models.Dogs;
using DbcWebApi.Models.Users;

namespace DbcWebApi.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();

            CreateMap<Dog, DogModel>();
            CreateMap<AddDogModel, Dog>();
            CreateMap<Dog, DogForSaleModel>().ForMember(item=> item.OwnerName, 
                opt => opt.MapFrom(src=> src.Owner.FirstName));
        }
    }
}