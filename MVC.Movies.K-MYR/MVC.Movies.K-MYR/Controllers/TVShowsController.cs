using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Movies.K_MYR.Data;
using MVC.Movies.K_MYR.Models;

namespace MVC.Movies.K_MYR.Controllers
{
    public class TVShowsController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<TVShowsController> _logger;

        public TVShowsController(ILogger<TVShowsController> logger, DatabaseContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ActionResult> Index() 
        {
            TVShowsFilterModel tvShows = new()
            {
                TVShows = await _context.TVShows.ToListAsync()
            };

            return View(tvShows);
        }
    }
}
