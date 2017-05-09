using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TwitterLikeWebAppWithDotNetCore.Models;

namespace TwitterLikeWebAppWithDotNetCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tweet> Tweets { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tweet>().ToTable("Tweet");
            builder.Entity<Message>().ToTable("Message");
            builder.Entity<Image>().ToTable("Image");
            base.OnModelCreating(builder);
        }
    }
}
