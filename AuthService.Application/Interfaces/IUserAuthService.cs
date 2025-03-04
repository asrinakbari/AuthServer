using AuthService.Application.Common;
using AuthService.Application.DTOs;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.Interfaces
{
    public interface IUserAuthService
    {
        Task<ServiceResult<string>> CreateUserAsync(UserSignUpDto user);
        Task<ServiceResult<string>> LoginAsync(LoginDto user);
    }
}
