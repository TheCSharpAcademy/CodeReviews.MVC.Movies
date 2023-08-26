using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Movies.MovieApi;
using Movies.Repositories;

namespace Movies.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IMovieApiService _movieApiService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AdminController(
        IMovieApiService movieApiService, 
        IUnitOfWork unitOfWork, 
        IMapper mapper)
    {
        _movieApiService = movieApiService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> FetchMovies([Bind("Rating")] Filter filter)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Index", controllerName: "Movie");
        }
        
        var moviesApiDto = await _movieApiService.FetchMovies(filter);

        var movies = _mapper.Map<IEnumerable<Movie>>(moviesApiDto);

        await _unitOfWork.Movies.AddEntities(movies);

        var count = await _unitOfWork.SaveChanges();

        if (count == 0)
        {
            return View("Index");
        }
        
        return RedirectToAction("Index", controllerName: "Movie");
    }
}
