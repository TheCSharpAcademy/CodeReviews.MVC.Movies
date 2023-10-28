using Microsoft.EntityFrameworkCore;
using Movies.wkktoria.Models;

namespace Movies.wkktoria.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Movie>? Movies { get; set; } = default!;
}