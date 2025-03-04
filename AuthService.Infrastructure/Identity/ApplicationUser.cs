using AuthService.Domain.Domain;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Infrastructure.Identity
{
    public class ApplicationUser: IdentityUser
    {
        public UserProfile userProfile { get; set; }
    }
}
