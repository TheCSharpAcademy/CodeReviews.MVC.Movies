using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MoviesManager.DB;

public class MoviesDB : DbContext
{
  public MoviesDB(DbContextOptions<MoviesDB> options) : base(options) { }
  public DbSet<Movie> Movies { get; set; }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Movie>().HasData(
        new Movie {Id=1, Title = "Dont", Price = 1.23F, ImageUrl="null" },
        new Movie { Id = 2, Title = "Let me", Price = 2.55F, ImageUrl = "null" },
        new Movie { Id = 3, Title = "down!", Price = 3.41F, ImageUrl = "null" }
        );

  }

}
public class Movie
{
  public int Id { get; set; }

  [Required]
  public string Title { get; set; }
  [Required]
  public float Price { get; set; }
  [ValidateNever]
  public string ImageUrl { get; set; }
}
