using AuthService.Application.DTOs;
using AuthService.Domain.Domain;
using AutoMapper;

namespace AuthService.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginDto, UserProfile>().ReverseMap();
            CreateMap<UserSignUpDto, UserProfile>().ReverseMap();
        }
    }
}
