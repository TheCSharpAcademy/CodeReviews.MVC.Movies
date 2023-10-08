using Microsoft.EntityFrameworkCore;
using MVC.TVShows.Forser.Models;

namespace MVC.TVShows.Forser.Data
{
    public class TVShowContext : DbContext
    {
        public DbSet<TVShow> TVShows { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public TVShowContext(DbContextOptions<TVShowContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}