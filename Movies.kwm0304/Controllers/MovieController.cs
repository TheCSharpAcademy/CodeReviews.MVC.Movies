using System.Diagnostics;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Movies.kwm0304.Models;

namespace Movies.kwm0304.Controllers;

public class MovieController : Controller
{
  public IActionResult Index()
  {
    return View();
  }

  public IActionResult Welcome(string name, int numTimes = 1)
  {
    ViewData["Message"] = "Hello" + name;
    ViewData["NumTimes"] = numTimes;
    return View();
  }

}
