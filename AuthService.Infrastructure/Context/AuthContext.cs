using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AuthService.Infrastructure.Identity;

namespace AuthService.Infrastructure.Context
{
    public class AuthContext(DbContextOptions<AuthContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
    }
}
