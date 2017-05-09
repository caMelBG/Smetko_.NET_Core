using Microsoft.AspNetCore.Identity;
using System.Linq;
using TwitterLikeWebAppWithDotNetCore.Models;

namespace TwitterLikeWebAppWithDotNetCore.Data
{
    public static class DbInitializer
    {
        public static async void Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var tweets = new Tweet[]
            {
                new Tweet{Content = "Tova e testov text!"},
                new Tweet{Content = "Tova e testov text!"},
                new Tweet{Content = "Tova e testov text!"},
                new Tweet{Content = "Tova e testov text!"},
                new Tweet{Content = "Tova e testov text!"},
                new Tweet{Content = "Tova e testov text!"},
                new Tweet{Content = "Tova e testov text!"}
            };
            foreach (var tweet in tweets)
            {
                await context.Tweets.AddAsync(tweet);
            }
            await context.SaveChangesAsync();

            var users = new ApplicationUser[]
            {
                new ApplicationUser{FirstName="Carson",LastName="Alexander"},
                new ApplicationUser{FirstName="Meredith",LastName="Alonso"},
                new ApplicationUser{FirstName="Arturo",LastName="Anand"},
                new ApplicationUser{FirstName="Gytis",LastName="Barzdukas"},
                new ApplicationUser{FirstName="Yan",LastName="Li"},
                new ApplicationUser{FirstName="Peggy",LastName="Justice"},
                new ApplicationUser{FirstName="Laura",LastName="Norman"},
                new ApplicationUser{FirstName="Nino",LastName="Olivetto"}
            };
            foreach (var user in users)
            {
                user.UserName = user.FirstName;
                user.Email = user.FirstName + "@abv.bg";
                await userManager.CreateAsync(user, user.FirstName);
            }
        }
    }
}
