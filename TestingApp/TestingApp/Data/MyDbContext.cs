namespace TestingApp.Models
{
    using Microsoft.EntityFrameworkCore;

    public class MyDbContext : DbContext
    {
        public MyDbContext (DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
