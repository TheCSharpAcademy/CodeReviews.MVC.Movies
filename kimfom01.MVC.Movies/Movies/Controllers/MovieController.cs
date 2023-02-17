using Microsoft.AspNetCore.Mvc;
using Movies.Repositories;
using Movies.Services;

namespace Movies.Controllers;

public class MovieController : Controller
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMovieAPIService _movieApiService;

    public MovieController(
        IMovieRepository movieRepository,
        IMovieAPIService movieApiService)
    {
        _movieRepository = movieRepository;
        _movieApiService = movieApiService;
    }

    public IActionResult Index(string searchString)
    {
        var movies = _movieRepository.GetEntities();

        movies = movies.OrderByDescending(mo => mo.Year).ToList();

        if (!string.IsNullOrWhiteSpace(searchString))
        {
            movies = movies.Where(
                mo => mo.Title.Contains(searchString)
                || mo.Genre.Contains(searchString));
        }

        return View(movies);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var movieDetailsDto = await _movieApiService.FetchDetails(id);

        return View(movieDetailsDto);
    }
}
