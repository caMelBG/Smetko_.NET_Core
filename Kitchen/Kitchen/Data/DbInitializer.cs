using Kitchen.Infrastructure;
using Kitchen.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Kitchen.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            var roles = new string[] { Constants.AdminRole, Constants.OperatorRole };
            foreach (var role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                roleStore.CreateAsync(new IdentityRole()
                {
                    Name = role,
                    NormalizedName = role.ToLower()
                });

                var user = new User
                {
                    UserName = role,
                    NormalizedUserName = role.ToLower(),
                    Email = string.Concat(role, "@", role, ".", role),
                    NormalizedEmail = string.Concat(role, "@", role, ".", role).ToLower(),
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var password = new PasswordHasher<User>();
                var hashed = password.HashPassword(user, role);
                user.PasswordHash = hashed;
                var userStore = new UserStore<User>(context);
                userStore.AddToRoleAsync(user, role.ToLower());
                userStore.CreateAsync(user);
            }
        }
    }
}
