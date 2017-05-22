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
            var roles = new string[] { Constants.OperatorRole, Constants.AdminRole };
            foreach (var role in roles)
            {
                if (!context.Roles.Any(r => r.Name == role))
                {
                    var roleStore = new RoleStore<IdentityRole>(context);
                    roleStore.CreateAsync(new IdentityRole()
                    {
                        Name = role,
                        NormalizedName = role.ToLower()
                    });
                }

                if (!context.Users.Any(u => u.UserName == role))
                {
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
                context.SaveChanges();
            }
        }
    }
}
