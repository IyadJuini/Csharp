using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionMvcApp.Models;
//! Session Config 3 -
using Microsoft.AspNetCore.Http;
//! ---------------------

namespace SessionMvcApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public static int NumberOfUsers = 0;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        HttpContext.Session.SetString("username", "John");
        HttpContext.Session.SetInt32("age", 40);
        HttpContext.Session.SetInt32("numberOfUsers", NumberOfUsers);
        System.Console.WriteLine($"Username : {HttpContext.Session.GetString("username")}\nAge : {HttpContext.Session.GetInt32("age")}");
        return View();
    }
    [HttpPost("users/create")]
    public IActionResult CreateUser(string name, int age, string favFood)
    {
        System.Console.WriteLine($"Name : {name}\nAge : {age}\nFavorite Food : {favFood}");
        HttpContext.Session.SetInt32("userAge", age);
        HttpContext.Session.SetString("name", name);
        HttpContext.Session.SetString("favFood", favFood);
        return RedirectToAction("Privacy");
    }
    public IActionResult Privacy()
    {
        if (HttpContext.Session.GetString("name") == null)
        {
            return RedirectToAction("Index");
        }
        NumberOfUsers += 1;
        HttpContext.Session.SetInt32("numberOfUsers", NumberOfUsers);
        return View();
    }
    [HttpPost("session/clear")]
    public IActionResult ClearSession()
    {
        HttpContext.Session.Clear();
        // return View("Privacy");
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
