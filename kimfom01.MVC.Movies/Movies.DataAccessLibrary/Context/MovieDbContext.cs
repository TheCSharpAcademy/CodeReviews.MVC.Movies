using Microsoft.EntityFrameworkCore;
using Movies.DataAccessLibrary.Models;

namespace Movies.DataAccessLibrary.Context;

public class MovieDbContext : DbContext
{
    public DbSet<MovieDbDto> Movies { get; set; }

    public MovieDbContext(DbContextOptions options) : base(options)
    {
    }
}
