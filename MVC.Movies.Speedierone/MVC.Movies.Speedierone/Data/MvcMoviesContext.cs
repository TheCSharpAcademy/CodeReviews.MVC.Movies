using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC.Movies.Speedierone.Models;

namespace MVC.Movies.Speedierone.Data
{
    public class MvcMoviesContext : DbContext
    {
        public MvcMoviesContext (DbContextOptions<MvcMoviesContext> options)
            : base(options)
        {
        }

        public DbSet<MVC.Movies.Speedierone.Models.Movie> Movie { get; set; } = default!;
    }
}
