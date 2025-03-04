using AuthService.Infrastructure.Identity;
using AuthService.Infrastructure.Interfaces;
using AuthService.Infrastructure.JwtService;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Infrastructure.Implements
{
    public class UserAuthRepository : IUserAuthRepository
    {
        private readonly JWTService _jwtService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public UserAuthRepository(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> 
            signInManager, JWTService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUser model)
        {
            var result = await _userManager.CreateAsync(model);
            return result;
        }

        public async Task<(SignInResult, string? )> LoginAsync(ApplicationUser model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null) return (SignInResult.Failed, null);

            var result = await _signInManager.PasswordSignInAsync(model,model.userProfile.Password, false, false);
            if (!result.Succeeded)
                return (result, null);

            var token = _jwtService.CreateToken(model);

            return (SignInResult.Success, token);
        }
    }
}
