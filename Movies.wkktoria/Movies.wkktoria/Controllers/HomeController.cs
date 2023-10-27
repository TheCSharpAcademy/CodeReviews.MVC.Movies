using Microsoft.AspNetCore.Mvc;

namespace Movies.wkktoria.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}