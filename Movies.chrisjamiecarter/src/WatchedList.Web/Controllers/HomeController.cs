using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WatchedList.Web.Models;

namespace WatchedList.Web.Controllers;

/// <summary>
/// Manages the home page and error handling for the WatchedList web application. 
/// This controller handles the basic navigation and presentation logic for the home page 
/// and provides an error view for unexpected issues.
/// </summary>
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
