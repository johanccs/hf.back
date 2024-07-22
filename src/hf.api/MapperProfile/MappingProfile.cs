using AutoMapper;
using hf.Api.Requests;
using hf.Domain.Entities;

namespace hf.Api.MapperProfile
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<NewUserRequest, User>().ReverseMap();
            CreateMap<LoginRequest, Login>().ReverseMap();
            CreateMap<NewProductRequest, Product>().ReverseMap();
        }
    }
}
