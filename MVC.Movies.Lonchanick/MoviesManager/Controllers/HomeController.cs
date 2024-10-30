using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MoviesManager.DB;
using MoviesManager.Models;
using System.Diagnostics;

namespace MoviesManager.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly MoviesDB movieDB; 

    public HomeController(ILogger<HomeController> logger, MoviesDB movieDB)
    {
      _logger = logger;
      this.movieDB = movieDB;
    }

    public IActionResult Index()
    {
      IEnumerable<Movie> movieList = movieDB.Movies.ToList();
      return View(movieList);
    }
    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Movie movie)
    {
      if (!ModelState.IsValid)
        return RedirectToAction("Index");

      movie.ImageUrl = "defaultPorElMomento";//temp
      movieDB.Add(movie);
      movieDB.SaveChanges();
      return RedirectToAction("index");
    }
    
    
    public IActionResult Delete (int? id)
    {
      var movie = movieDB.Movies.FirstOrDefault(movie => movie.Id == id);

      if (movie is null)
        return RedirectToAction("Index");

      movieDB.Remove(movie);
      movieDB.SaveChanges();

      return RedirectToAction("Index");

    }

    public IActionResult Details (int? id)
    {
      return View(movieDB.Movies.FirstOrDefault(m => m.Id == id));
    }

    public IActionResult Update(int? id)
    {
      return View(movieDB.Movies.FirstOrDefault(m => m.Id == id));
    }

    [HttpPost]
    public IActionResult Update(Movie movie)
    {
      if (!ModelState.IsValid)
        return RedirectToAction("index");

      movieDB.Update(movie);
      movieDB.SaveChanges();
      return RedirectToAction("index");
    }


    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
