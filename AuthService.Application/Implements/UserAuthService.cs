using AuthService.Application.Common;
using AuthService.Application.DTOs;
using AuthService.Application.Interfaces;
using AuthService.Infrastructure.Identity;
using AuthService.Infrastructure.Interfaces;
using AutoMapper;

namespace AuthService.Application.Implements
{
    public class UserAuthService : IUserAuthService 
    {
        private readonly IMapper _mapper;
        private readonly IUserAuthRepository _userAuthRepository;
        public UserAuthService(IMapper mapper, IUserAuthRepository userAuthRepository)
        {
            _mapper = mapper;
            _userAuthRepository = userAuthRepository;
        }

        public async Task<ServiceResult> CreateUserAsync(UserSignUpDto user)
        {
            var model = _mapper.Map<ApplicationUser>(user);
            var result = await _userAuthRepository.CreateUserAsync(model);
            if (result.Succeeded)
            {
                return new ServiceResult()
                {
                    Message = "کاربر با موفقیت ساخته شد",
                    Status = ResponseStatus.Success
                };
            }

            var errors = result.Errors.Select(e => e.Description).ToList();
            return new ServiceResult()
            {
                Message = "خطایی در ثبت کاربر رخ داده است",
                Status = ResponseStatus.Error,
                Errors = errors
            };
        }

        public async Task<ServiceResult> LoginAsync(LoginDto user)
        {
            var model = _mapper.Map<ApplicationUser>(user);
            var (signInResult, token) = await _userAuthRepository.LoginAsync(model);

            if (signInResult.Succeeded)
                return new ServiceResult()
                {
                    Message = "ورود با موفقیت انجام شد",
                    Token = token,
                    Status = ResponseStatus.Success
                };


            if (signInResult.IsLockedOut)
                return new ServiceResult()
                {
                    Message = "حساب شما قفل شده است. لطفاً بعداً تلاش کنید.",
                    Status = ResponseStatus.Error
                };

            if (signInResult.IsNotAllowed)
                return new ServiceResult()
                {
                    Message = "دسترسی به این حساب امکان‌پذیر نیست.",
                    Status = ResponseStatus.Unauthorized
                };


            return new ServiceResult()
            {
                Message = "نام کاربری یا رمز عبور اشتباه است.",
                Status = ResponseStatus.Error
            };
        }
    }
}
