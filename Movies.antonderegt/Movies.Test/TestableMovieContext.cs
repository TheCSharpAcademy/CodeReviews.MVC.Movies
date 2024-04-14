using Microsoft.EntityFrameworkCore;
using Movie.Data;

namespace Movies.Test;

public class TestableMovieContext : MovieContext
{
    public TestableMovieContext() : base(new DbContextOptionsBuilder<MovieContext>().Options)
    {
    }
}