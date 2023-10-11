using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyWithValidation.Models;

namespace DojoSurveyWithValidation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("create")]
    // public IActionResult CreateForm(string name, string location, string favLanguage )
    public IActionResult CreateForm(Dojo newDojo)
    {

        System.Console.WriteLine($"Name : {newDojo.Name}\nLocation : {newDojo.Location}\n Fav Lang : {newDojo.FavLanguage}\nComment : {newDojo.Comment}");
        if (ModelState.IsValid)
        {
            return RedirectToAction("Result", newDojo);
        }
        return View("Index");
    }

    public IActionResult Result(Dojo dojo)
    {
        return View(dojo);
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