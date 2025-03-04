using AuthService.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Infrastructure.Interfaces
{
    public interface IUserAuthRepository
    {
        Task<IdentityResult> CreateUserAsync(ApplicationUser user);
        Task<(SignInResult, string?)> LoginAsync(ApplicationUser user);
    }
}
