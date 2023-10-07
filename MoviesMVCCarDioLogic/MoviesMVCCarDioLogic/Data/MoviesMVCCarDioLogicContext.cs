using Microsoft.EntityFrameworkCore;
using MoviesMVCCarDioLogic.Models;

namespace MoviesMVCCarDioLogic.Data
{
    public class MoviesMVCCarDioLogicContext : DbContext
    {
        public MoviesMVCCarDioLogicContext (DbContextOptions<MoviesMVCCarDioLogicContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Serie> Serie { get; set; } 
    }
}
