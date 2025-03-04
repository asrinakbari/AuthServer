using AuthService.Application.Common;
using AuthService.Application.DTOs;
using AuthService.Application.Interfaces;
using AuthService.Infrastructure.Identity;
using AuthService.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

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

        public async Task<ServiceResult<string>> CreateUserAsync(UserSignUpDto user)
        {
            var model = _mapper.Map<ApplicationUser>(user);
            var result = await _userAuthRepository.CreateUserAsync(model);
            if (result.Succeeded)
            {
                return ServiceResult<string>.Success(model.Id, "کاربر با موفقیت ثبت شد");
            }

            var errors = result.Errors.Select(e => e.Description).ToList();
            return ServiceResult<string>.Error("خطایی در ثبت کاربر رخ داده است", errors);
        }

        public async Task<ServiceResult<string>> LoginAsync(LoginDto user)
        {
            var model = _mapper.Map<ApplicationUser>(user);
            var (signInResult, token) = await _userAuthRepository.LoginAsync(model);

            if (signInResult.Succeeded)
                return ServiceResult<string>.Success(token!, "ورود با موفقیت انجام شد");

            if (signInResult.IsLockedOut)
                return ServiceResult<string>.Error("حساب شما قفل شده است. لطفاً بعداً تلاش کنید.");

            if (signInResult.IsNotAllowed)
                return ServiceResult<string>.Error("دسترسی به این حساب امکان‌پذیر نیست.");

            return ServiceResult<string>.Error("نام کاربری یا رمز عبور اشتباه است.");
        }
    }
}
