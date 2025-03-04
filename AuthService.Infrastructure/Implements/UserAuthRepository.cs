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
            var hashedPassword = _userManager.PasswordHasher.HashPassword(model, model.userProfile.Password);
            model.PasswordHash = hashedPassword;

            var result = await _userManager.CreateAsync(model);
            return result;
        }

        public async Task<(SignInResult, string? )> LoginAsync(ApplicationUser model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null) return (SignInResult.Failed, null);


            var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.userProfile.Password);

            if (result != PasswordVerificationResult.Success)
                return (SignInResult.Failed, null);

            var token = _jwtService.CreateToken(model);

            return (SignInResult.Success, token);
        }
    }
}
