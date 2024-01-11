using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieMvc.Models;

namespace MovieMvc.Data
{
    public class MovieMvcContext : DbContext
    {
        public MovieMvcContext (DbContextOptions<MovieMvcContext> options)
            : base(options)
        {
        }

        public DbSet<MovieMvc.Models.Movie> Movie { get; set; } = default!;
    }
}
