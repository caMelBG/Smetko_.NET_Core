using Microsoft.AspNetCore.Identity;
using System.Linq;
using TwitterLikeWebAppWithDotNetCore.Models;

namespace TwitterLikeWebAppWithDotNetCore.Data
{
    public static class DbInitializer
    {
        public static async void Initialize(ApplicationDbContext context, UserManager<User> userManager)
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

            var users = new User[]
            {
                new User{FirstName="Carson",LastName="Alexander"},
                new User{FirstName="Meredith",LastName="Alonso"},
                new User{FirstName="Arturo",LastName="Anand"},
                new User{FirstName="Gytis",LastName="Barzdukas"},
                new User{FirstName="Yan",LastName="Li"},
                new User{FirstName="Peggy",LastName="Justice"},
                new User{FirstName="Laura",LastName="Norman"},
                new User{FirstName="Nino",LastName="Olivetto"}
            };
            foreach (var user in users)
            {
                user.Tweets = tweets;
                await userManager.CreateAsync(user, "parola");
            }
            await context.SaveChangesAsync();
        }
    }
}
