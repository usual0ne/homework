using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Data
{
    public class MoviesContext : DbContext
    {
        public MoviesContext (DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MoviesActors> MoviesActors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesActors>(entity =>
            {
                entity.HasKey(ma => new { ma.MovieId, ma.ActorId });
            });
        }
    }
}