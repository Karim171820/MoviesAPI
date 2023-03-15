using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
