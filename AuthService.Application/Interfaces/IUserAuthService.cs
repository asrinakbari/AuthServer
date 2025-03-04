using AuthService.Application.Common;
using AuthService.Application.DTOs;

namespace AuthService.Application.Interfaces
{
    public interface IUserAuthService
    {
        Task<ServiceResult> CreateUserAsync(UserSignUpDto user);
        Task<ServiceResult> LoginAsync(LoginDto user);
    }
}
