using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;

namespace RandomPasscode.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        int? passCount = HttpContext.Session.GetInt32("passCount");
        if (passCount == null)
        {
            HttpContext.Session.SetInt32("passCount", 0);

        }
        passCount++;
        HttpContext.Session.SetInt32("passCount", (int)passCount!);
        System.Console.WriteLine("PASSSSS count: " + passCount);
        string alphaNum = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var RandomPasscode = new char[14];
        var rand = new Random();
        for (int i = 0; i < RandomPasscode.Length; i++)
        {

            RandomPasscode[i] = alphaNum[rand.Next(alphaNum.Length)];
        }
        string generatedPass = new String(RandomPasscode);

        return View("Index", generatedPass);
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
