using Microsoft.EntityFrameworkCore;
using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Data
{
    public class MoviesDataContext : DbContext
    {
        public MoviesDataContext(DbContextOptions<MoviesDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().Navigation(x => x.Actors).AutoInclude();
            modelBuilder.Entity<Movie>().Navigation(x => x.Producer).AutoInclude();

            modelBuilder.Entity<Movie>().HasMany(x => x.Actors);
            modelBuilder.Entity<Actor>().HasMany(x => x.Movies);
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Produers { get; set; }

    }
}
