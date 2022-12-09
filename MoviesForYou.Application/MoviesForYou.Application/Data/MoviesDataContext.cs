using Microsoft.EntityFrameworkCore;
using MoviesForYou.Application.API.Models;

namespace MoviesForYou.Application.API.Data
{
    public class MoviesDataContext : DbContext
    {
        public MoviesDataContext(DbContextOptions<MoviesDataContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Produers { get; set; }

    }
}
