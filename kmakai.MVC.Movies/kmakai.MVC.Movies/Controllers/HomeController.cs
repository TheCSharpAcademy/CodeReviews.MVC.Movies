using kmakai.MVC.Movies.DataAccess;
using kmakai.MVC.Movies.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace kmakai.MVC.Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string searchString)
        {
            
            var movies = from m in _context.Movies
                         select m;
            var books = from b in _context.Books
                        select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
                books = books.Where(s => s.Title.Contains(searchString) || s.Author.Contains(searchString));
            }

            ViewData["Movies"] = movies;
            ViewData["Books"] = books;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}