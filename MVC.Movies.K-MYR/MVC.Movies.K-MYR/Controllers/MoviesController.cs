using Microsoft.AspNetCore.Mvc;

namespace MVC.Movies.K_MYR;

public class MoviesController : Controller
{
    private readonly ILogger<MoviesController> _logger;

    public MoviesController(ILogger<MoviesController> logger)
    {
        _logger = logger;        
    }

    public IActionResult Index()
    {
        return View();
    }
}
