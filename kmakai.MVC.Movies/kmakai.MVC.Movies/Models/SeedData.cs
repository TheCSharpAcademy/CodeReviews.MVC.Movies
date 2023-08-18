using kmakai.MVC.Movies.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace kmakai.MVC.Movies.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            if (context.Books.Any() && context.Movies.Any())
            {
                return;
            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(
                 new Book
                 {
                     Title = "Harry Potter and the Sorcerer's Stone",
                     Author = "J.K. Rowling",
                     Published = DateTime.Parse("1997-6-26"),
                     Genre = "Fantasy",
                     Price = 7.99M
                 },
                 new Book
                 {
                     Title = "The Fellowship of the Ring",
                     Author = "J.R.R. Tolkien",
                     Published = DateTime.Parse("1954-7-29"),
                     Genre = "Fantasy",
                     Price = 8.99M
                 },
                 new Book
                 {
                     Title = "The Two Towers",
                     Author = "J.R.R. Tolkien",
                     Published = DateTime.Parse("1954-11-11"),
                     Genre = "Fantasy",
                     Price = 9.99M
                 },
                 new Book
                 {
                     Title = "The cat in the hat",
                     Author = "Dr. Seuss",
                     Published = DateTime.Parse("1957-3-12"),
                     Genre = "Children's",
                     Price = 4.99M
                 }
                 );
            }



            if (!context.Movies.Any())
            {
                context.Movies.AddRange(
               new Movie
               {
                   Title = "Harry Potter and the Sorcerer's Stone",
                   ReleaseDate = DateTime.Parse("2001-11-16"),
                   Genre = "Fantasy",
                   Price = 7.99M
               },
               new Movie
               {
                   Title = "The Fellowship of the Ring",
                   ReleaseDate = DateTime.Parse("2001-12-19"),
                   Genre = "Fantasy",
                   Price = 8.99M
               },
               new Movie
               {
                   Title = "The Two Towers",
                   ReleaseDate = DateTime.Parse("2002-12-18"),
                   Genre = "Fantasy",
                   Price = 9.99M
               },

               new Movie
               {
                   Title = "The Mask",
                   ReleaseDate = DateTime.Parse("1994-7-29"),
                   Genre = "Comedy",
                   Price = 7.99M
               }
               );
            }



            context.SaveChanges();
        }

    }
}
