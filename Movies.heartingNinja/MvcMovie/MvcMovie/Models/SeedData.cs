using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
        {
    
            if (context.Movie.Any())
            {
                return; 
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "The Shawshank Redemption",
                    ReleaseDate = DateTime.Parse("1994-10-14"),
                    Genre = "Drama",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "The Godfather",
                    ReleaseDate = DateTime.Parse("1972-03-24"),
                    Genre = "Crime",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Pulp Fiction",
                    ReleaseDate = DateTime.Parse("1994-10-14"),
                    Genre = "Crime",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "The Dark Knight",
                    ReleaseDate = DateTime.Parse("2008-07-18"),
                    Genre = "Action",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Fight Club",
                    ReleaseDate = DateTime.Parse("1999-10-15"),
                    Genre = "Drama",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Inception",
                    ReleaseDate = DateTime.Parse("2010-07-16"),
                    Genre = "Action",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "The Matrix",
                    ReleaseDate = DateTime.Parse("1999-03-31"),
                    Genre = "Action",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Forrest Gump",
                    ReleaseDate = DateTime.Parse("1994-07-06"),
                    Genre = "Drama",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Goodfellas",
                    ReleaseDate = DateTime.Parse("1990-09-19"),
                    Genre = "Crime",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    ReleaseDate = DateTime.Parse("2001-12-19"),
                    Genre = "Adventure",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M
                },
                 new Movie
                 {
                     Title = "Ghostbusters ",
                     ReleaseDate = DateTime.Parse("1984-3-13"),
                     Genre = "Comedy",
                     Price = 8.99M
                 },
                 new Movie
                 {
                     Title = "Ghostbusters 2",
                     ReleaseDate = DateTime.Parse("1986-2-23"),
                     Genre = "Comedy",
                     Price = 9.99M
                 },
                 new Movie
                 {
                     Title = "Rio Bravo",
                     ReleaseDate = DateTime.Parse("1959-4-15"),
                     Genre = "Western",
                     Price = 3.99M
                 },
                 new Movie
                 {
                     Title = "The Shawshank Redemption 2",
                     ReleaseDate = DateTime.Parse("2000-05-10"),
                     Genre = "Drama",
                     Price = 12.99M
                 },
                 new Movie
                 {
                     Title = "The Godfather Part II",
                     ReleaseDate = DateTime.Parse("1974-12-20"),
                     Genre = "Crime",
                     Price = 10.99M
                 },
                 new Movie
                 {
                     Title = "Blade Runner",
                     ReleaseDate = DateTime.Parse("1982-06-25"),
                     Genre = "Sci-Fi",
                     Price = 9.99M
                 },
                 new Movie
                 {
                     Title = "The Silence of the Lambs",
                     ReleaseDate = DateTime.Parse("1991-02-14"),
                     Genre = "Thriller",
                     Price = 8.99M
                 },
                 new Movie
                 {
                     Title = "The Lion King",
                     ReleaseDate = DateTime.Parse("1994-06-24"),
                     Genre = "Animation",
                     Price = 9.99M
                 },
                 new Movie
                 {
                     Title = "The Social Network",
                     ReleaseDate = DateTime.Parse("2010-10-01"),
                     Genre = "Drama",
                     Price = 7.99M
                 },
                 new Movie
                 {
                     Title = "Inglourious Basterds",
                     ReleaseDate = DateTime.Parse("2009-08-21"),
                     Genre = "War",
                     Price = 8.99M
                 },
                 new Movie
                 {
                     Title = "Back to the Future",
                     ReleaseDate = DateTime.Parse("1985-07-03"),
                     Genre = "Sci-Fi",
                     Price = 9.99M
                 },
                 new Movie
                 {
                     Title = "The Shining",
                     ReleaseDate = DateTime.Parse("1980-05-23"),
                     Genre = "Horror",
                     Price = 7.99M
                 },
                 new Movie
                 {
                     Title = "Casablanca",
                     ReleaseDate = DateTime.Parse("1942-11-26"),
                     Genre = "Romance",
                     Price = 8.99M
                 }
            );
            context.SaveChanges();
        }
    }
}
