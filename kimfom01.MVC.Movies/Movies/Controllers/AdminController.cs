using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Movies.Repositories;
using Movies.Services;

namespace Movies.Controllers;

public class AdminController : Controller
{
    private readonly IMovieAPIService _movieAPIService;
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public AdminController(
        IMovieAPIService movieAPIService, 
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
            var moviesDto = await _movieAPIService.FetchMovies(filter);

            var movies = _mapper.Map<IEnumerable<Movie>>(moviesDto);

            await _movieRepository.AddEntities(movies);

            await _movieRepository.SaveChanges();
        }

        return View("Index");
    }
}
