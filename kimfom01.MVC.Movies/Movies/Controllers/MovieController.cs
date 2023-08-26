using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Movies.Repositories;

namespace Movies.Controllers;

[Authorize]
public class MovieController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public MovieController(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        UserManager<ApplicationUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
    }
    
    public IActionResult Index(string searchString)
    {
        var movies = _unitOfWork.Movies.GetEntities();

        movies = movies.OrderByDescending(mo => mo.Year).ToList();

        if (!string.IsNullOrWhiteSpace(searchString))
        {
            movies = SearchForMovies(searchString, movies);
        }

        return View(movies);
    }

    private IEnumerable<Movie> SearchForMovies(string searchString, IEnumerable<Movie> movies)
    {
        movies = movies.Where(mo => mo.Title.ToLower().Contains(searchString.ToLower())
                                    || mo.Genre.ToLower().Contains(searchString.ToLower()));

        return movies;
    }

    public async Task<IActionResult> Details(int? movieId)
    {
        if (movieId is null)
        {
            return NotFound();
        }

        var movie = await _unitOfWork.Movies.GetOneEntity(mov => mov.MovieId == movieId);

        if (movie is null)
        {
            return NotFound();
        }

        var details = _mapper.Map<Details>(movie);

        return View(details);
    }

    public async Task<IActionResult> AddLikedMovie(int? movieId)
    {
        if (movieId is null)
        {
            return NotFound();
        }

        var userId = _userManager.GetUserId(User);

        if (_unitOfWork.LikedMovies.CheckMovie(movieId, userId))
        {
            return RedirectToAction("Index");
        }

        var movie = await _unitOfWork.Movies.GetOneEntity(mov => mov.MovieId == movieId);

        if (movie is null)
        {
            return NotFound();
        }

        var likedMovie = _mapper.Map<LikedMovie>(movie);
        likedMovie.UserId = _userManager.GetUserId(User)!;

        await _unitOfWork.LikedMovies.AddEntity(likedMovie);
        await _unitOfWork.SaveChanges();

        return RedirectToAction("Index");
    }
}