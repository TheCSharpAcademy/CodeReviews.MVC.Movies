using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movies.JsPeanut.Models;

namespace Movies.JsPeanut.Data
{
    public class MoviesJsPeanutContext : DbContext
    {
        public MoviesJsPeanutContext (DbContextOptions<MoviesJsPeanutContext> options)
            : base(options)
        {
        }

        public DbSet<Movies.JsPeanut.Models.Movie> Movie { get; set; } = default!;
    }
}
