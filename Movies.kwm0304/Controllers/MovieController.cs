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

  public string Welcome(string name, int numTimes = 1)
  {
    return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
  }

}
