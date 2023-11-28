using ApiTutorials.DTOs;
using ApiTutorials.Entities.Users;
using AutoMapper;

namespace ApiTutorials.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<User, UserResultDto>().ReverseMap();
        }
    }
}
