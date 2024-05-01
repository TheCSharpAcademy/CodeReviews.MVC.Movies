using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movie.Data;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Moq;

using Movies.Controllers;

namespace Movies.Test;

public class MoviesControllerTests
{
    [Fact]
    public async void Create_WithValidMovie_AddsMovieToContext()
    {
        var mockContext = new Mock<TestableMovieContext>();
        var mockSet = new Mock<DbSet<Movie.Models.Movie>>();
        mockContext.Setup(context => context.Movies).Returns(mockSet.Object);

        var service = new MoviesController(mockContext.Object);
        Movie.Models.Movie movie = new()
        {
            Title = "Test Movie",
            ReleaseDate = DateTime.Now,
            Genre = "Action",
            Price = 9.99M,
            Rating = "PG-13",
            Image = "https://www.example.com/image.jpg"
        };
        var created = await service.Create(movie);

        Assert.IsType<RedirectToActionResult>(created);
        mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        mockContext.Verify(m => m.Add(It.Is<Movie.Models.Movie>(m => m.Title == movie.Title)), Times.Once());
    }

    [Fact]
    public void Index_WithData_ReturnsActionResult()
    {
        var data = new List<Movie.Models.Movie>
            {
                new()
                    {
                        Title = "Test Movie",
                        ReleaseDate = DateTime.Now,
                        Genre = "Action",
                        Price = 9.99M,
                        Rating = "PG-13",
                        Image = "https://www.example.com/image.jpg"
                    },
                new()
                    {
                        Title = "Test Movie 2",
                        ReleaseDate = DateTime.Now,
                        Genre = "Action",
                        Price = 9.99M,
                        Rating = "PG-13",
                        Image = "https://www.example.com/image.jpg"
                    },
            }.AsQueryable();

        var mockSet = new Mock<DbSet<Movie.Models.Movie>>();
        mockSet.As<IQueryable<Movie.Models.Movie>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<Movie.Models.Movie>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<Movie.Models.Movie>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<Movie.Models.Movie>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

        var mockContext = new Mock<TestableMovieContext>();
        mockContext.Setup(context => context.Movies).Returns(mockSet.Object);

        var service = new MoviesController(mockContext.Object);
        var response = service.Index("Action", "Test Movie 2");

        Assert.IsType<Task<IActionResult>>(response);
    }
}