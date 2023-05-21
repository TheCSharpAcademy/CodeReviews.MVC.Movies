using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Movies.Repositories;

namespace Movies.Controllers;

[Authorize]
public class MyMoviesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public MyMoviesController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userManager = userManager;
    }
    
    public IActionResult Index()
    {
        var userId = _userManager.GetUserId(User);
        
        var likedMovies = _unitOfWork.LikedMovies.GetLikedMovies(userId!);
        
        return View(likedMovies);
    }

    public async Task<IActionResult> Details(int? movieId)
    {
        if (movieId is null)
        {
            return NotFound();
        }

        var userId = _userManager.GetUserId(User);
        
        var movie = await _unitOfWork.LikedMovies
            .GetOneEntity(mov => mov.MovieId == movieId && mov.UserId == userId);

        if (movie is null)
        {
            return NotFound();
        }

        var details = _mapper.Map<Details>(movie);

        return View(details);
    }

    [HttpPost]
    public async Task<IActionResult> Details(Status status, int movieId)
    {
        var userId = _userManager.GetUserId(User);
        
        var movie = await _unitOfWork.LikedMovies
            .GetOneEntity(mov => mov.MovieId == movieId && mov.UserId == userId);
    
        if (movie is null)
        {
            return NotFound();
        }
    
        movie.Status = status;
    
        await _unitOfWork.SaveChanges();
    
        return RedirectToAction("Details", new { movie.MovieId });
    }
}