using AuthService.Application.DTOs;
using AuthService.Application.Interfaces;
using AuthService.Grpc.Services.Interfaces;
using AutoMapper;

namespace AuthService.Grpc.Services.Implements
{
    public class AuthGrpcService : IAuthGrpcService
    {
        private readonly IMapper _mapper ;
        private readonly IUserAuthService _userAuthService;
        public AuthGrpcService(IUserAuthService userAuthService, IMapper mapper)
        {
            _mapper = mapper;
            _userAuthService = userAuthService;
        }
        public async Task<ServiceResultReply> CreateUserAsync(UserSignUpRequest request)
        {
            var dto = _mapper.Map<UserSignUpDto>(request);
            var result = await _userAuthService.CreateUserAsync(dto);

            var response =  new ServiceResultReply()
            {
                Status = (ResponseStatusGrpc)result.Status,
                Token = result.Token,
                Message = result.Message,
            };

            response.Errors.AddRange(result.Errors);

            return response;
        }

        public async Task<ServiceResultReply> LoginAsync(LoginRequest request)
        {
            var dto = _mapper.Map<LoginDto>(request);
            var result = await _userAuthService.LoginAsync(dto);

            var response = new ServiceResultReply()
            {
                Status = (ResponseStatusGrpc)result.Status,
                Message = result.Message,
            };

            response.Errors.AddRange(result.Errors);

            return response;
        }
    }
}
