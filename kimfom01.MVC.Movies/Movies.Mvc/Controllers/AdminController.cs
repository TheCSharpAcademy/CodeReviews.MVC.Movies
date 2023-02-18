using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.DataAccessLibrary.Repositories;
using Movies.DataAccessLibrary.Models;
using Movies.ApiService.MovieApi;
using Movies.ApiService.Models;

namespace Movies.Controllers;

public class AdminController : Controller
{
    private readonly IMovieApiService _movieAPIService;
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public AdminController(
        IMovieApiService movieAPIService, 
        IMovieRepository movieRepository, 
        IMapper mapper)
    {
        _movieAPIService = movieAPIService;
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
            var moviesApiDto = await _movieAPIService.FetchMovies(filter);

            var movies = _mapper.Map<IEnumerable<MovieDbDto>>(moviesApiDto);

            await _movieRepository.AddEntities(movies);

            await _movieRepository.SaveChanges();
        }

        return View("Index");
    }
}
