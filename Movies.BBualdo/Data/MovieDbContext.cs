using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class MovieDbContext(DbContextOptions<MovieDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.SeedMovies();
    }
}

public static class ModelBuilderExtensions
{
    public static void SeedMovies(this ModelBuilder modelBuilder)
    {
        var movies = new List<Movie>
        {
            new()
            {
                Id = 1, Title = "Toy Story 2", Genre = "Animation", ReleaseDate = new DateOnly(1999, 11, 13),
                Price = 24.99m,
                ImageUrl =
                    "https://m.media-amazon.com/images/M/MV5BMWM5ZDcxMTYtNTEyNS00MDRkLWI3YTItNThmMGExMWY4NDIwXkEyXkFqcGdeQXVyNjUwNzk3NDc@._V1_.jpg"
            },
            new()
            {
                Id = 2, Title = "The Matrix", Genre = "Science Fiction", ReleaseDate = new DateOnly(1999, 3, 31),
                Price = 19.99m, ImageUrl = "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_.jpg"
            },
            new()
            {
                Id = 3, Title = "Inception", Genre = "Action", ReleaseDate = new DateOnly(2010, 7, 16), Price = 29.99m, ImageUrl = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_FMjpg_UX1000_.jpg"
            },
            new()
            {
                Id = 4, Title = "The Shawshank Redemption", Genre = "Drama", ReleaseDate = new DateOnly(1994, 9, 23),
                Price = 14.99m, ImageUrl = "https://m.media-amazon.com/images/M/MV5BNDE3ODcxYzMtY2YzZC00NmNlLWJiNDMtZDViZWM2MzIxZDYwXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_FMjpg_UX1000_.jpg"
            },
            new()
            {
                Id = 5, Title = "Pulp Fiction", Genre = "Crime", ReleaseDate = new DateOnly(1994, 10, 14),
                Price = 18.99m, ImageUrl = "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_.jpg"
            },
            new()
            {
                Id = 6, Title = "The Dark Knight", Genre = "Action", ReleaseDate = new DateOnly(2008, 7, 18),
                Price = 24.99m, ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_FMjpg_UX1000_.jpg"
            },
            new()
            {
                Id = 7, Title = "Forrest Gump", Genre = "Drama", ReleaseDate = new DateOnly(1994, 7, 6), Price = 17.99m, ImageUrl = "https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_FMjpg_UX1000_.jpg"
            },
            new()
            {
                Id = 8, Title = "The Lion King", Genre = "Animation", ReleaseDate = new DateOnly(1994, 6, 24),
                Price = 19.99m, ImageUrl = "https://m.media-amazon.com/images/M/MV5BYTYxNGMyZTYtMjE3MS00MzNjLWFjNmYtMDk3N2FmM2JiM2M1XkEyXkFqcGdeQXVyNjY5NDU4NzI@._V1_.jpg"
            },
            new()
            {
                Id = 9, Title = "Gladiator", Genre = "Action", ReleaseDate = new DateOnly(2000, 5, 5), Price = 21.99m, ImageUrl = "https://m.media-amazon.com/images/M/MV5BMDliMmNhNDEtODUyOS00MjNlLTgxODEtN2U3NzIxMGVkZTA1L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_.jpg"
            },
            new()
            {
                Id = 10, Title = "Titanic", Genre = "Romance", ReleaseDate = new DateOnly(1997, 12, 19), Price = 22.99m, ImageUrl = "https://m.media-amazon.com/images/M/MV5BMDdmZGU3NDQtY2E5My00ZTliLWIzOTUtMTY4ZGI1YjdiNjk3XkEyXkFqcGdeQXVyNTA4NzY1MzY@._V1_FMjpg_UX1000_.jpg"
            }
        };
        modelBuilder.Entity<Movie>().HasData(movies);
    }
}