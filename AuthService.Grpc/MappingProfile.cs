using AuthService.Application.Common;
using AuthService.Application.DTOs;
using AutoMapper;

namespace AuthService.Grpc
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserSignUpRequest , UserSignUpDto>();
            CreateMap<LoginRequest, LoginDto>();
            CreateMap<ServiceResult, ServiceResultReply>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Errors ?? new List<string>()));
        }
    }
}
