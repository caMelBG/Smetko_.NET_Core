using Kitchen.Infrastructure;
using Kitchen.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Linq;

namespace Kitchen.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
              context.Database.EnsureCreated();

            if (context.UserRoles.Any())
            {
                return;
            }

            var roles = new string[] { Constants.AdminRole, Constants.OperatorRole };
            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                roleStore.CreateAsync(new IdentityRole(role));
                
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
                userStore.CreateAsync(user);
                userStore.AddToRoleAsync(user, role.ToLower());
            }
        }
    }
}
