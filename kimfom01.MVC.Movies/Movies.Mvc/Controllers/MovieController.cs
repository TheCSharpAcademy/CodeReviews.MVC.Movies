using Microsoft.AspNetCore.Mvc;
using Movies.DataAccessLibrary.Repositories;
using Movies.ApiService.MovieApi;
using AutoMapper;
using Movies.Mvc.Models;

namespace Movies.Controllers;

public class MovieController : Controller
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMovieApiService _movieApiService;
    private readonly IMapper _mapper;

    public MovieController(
        IMovieRepository movieRepository,
        IMovieApiService movieApiService,
        IMapper mapper)
    {
        _movieRepository = movieRepository;
        _movieApiService = movieApiService;
        _mapper = mapper;
    }

    public IActionResult Index(string searchString)
    {
        var movieDbDtos = _movieRepository.GetEntities();

        var movies = _mapper.Map<IEnumerable<Movie>>(movieDbDtos);

        movies = movies.OrderByDescending(mo => mo.Year).ToList();

        if (!string.IsNullOrWhiteSpace(searchString))
        {
            movies = SearchForMovies(searchString, movies);
        }

        return View(movies);
    }

    private static IEnumerable<Movie> SearchForMovies(string searchString, IEnumerable<Movie> movies)
    {
        movies = movies.Where(mo => mo.Title.ToLower().Contains(searchString.ToLower()) 
            || mo.Genre.ToLower().Contains(searchString.ToLower()));

        return movies;
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var movie = await _movieRepository.GetOneEntity(mov => mov.Id == id);

        if(movie is null)
        {
            return NotFound();
        }

        var details = _mapper.Map<Details>(movie);

        return View(details);
    }
}
