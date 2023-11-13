using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog_prueba.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //roles user, admin, superAdmin
            var adminRoleId = "8d471e00-36f3-4281-b78e-ba725d21e7e7";
            var superAdminRoleId = "ee564df0-74e7-4b03-a0d0-1efa1f9e466b";
            var userRoleId = "aa8656cc-2bb9-497d-b487-e6f58e864763";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName="SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id=userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            //crear rol superAdmin
            var superAdminId = "ab2fb769-add1-409d-a779-c78145c4cbc6";

            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@blog.com",
                Email = "superadmin@blog.com",
                NormalizedEmail = "superadmin@blog.com".ToUpper(),
                NormalizedUserName = "superadmin@blog.com".ToUpper(),
                Id = superAdminId
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "SuperAdmin1223");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            //darle permisos al SuperAdmin
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
