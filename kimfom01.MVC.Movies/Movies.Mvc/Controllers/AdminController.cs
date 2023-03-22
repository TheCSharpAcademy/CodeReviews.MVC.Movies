using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.ApiService.Models;
using Movies.ApiService.MovieApi;
using Movies.DataAccessLibrary.Models;
using Movies.DataAccessLibrary.Repositories;

namespace Movies.Mvc.Controllers;

public class AdminController : Controller
{
    private readonly IMovieApiService _movieApiService;
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public AdminController(
        IMovieApiService movieApiService, 
        IMovieRepository movieRepository, 
        IMapper mapper)
    {
        _movieApiService = movieApiService;
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> FetchMovies([Bind("Rating")] Filter filter)
    {
        if (ModelState.IsValid)
        {
            var moviesApiDto = await _movieApiService.FetchMovies(filter);

            var movies = _mapper.Map<IEnumerable<MovieDbDto>>(moviesApiDto);

            await _movieRepository.AddEntities(movies);

            await _movieRepository.SaveChanges();
        }

        return RedirectToAction("Index", controllerName: "Movie");
    }
}
