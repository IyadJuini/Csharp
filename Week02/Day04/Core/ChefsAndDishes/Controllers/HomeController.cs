using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsAndDishes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ChefsAndDishes.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

//******************************************** CHEFS ********************************

    public IActionResult Index()
    {
        List<Chef> AllChefs = _context.Chefs.Include(p => p.MyDishes).ToList();
        return View(AllChefs);
    }

//******************************************** DISHES ********************************
    public IActionResult Privacy()
    {
        List<Dish> AllDishes = _context.Dishes.Include(p=> p.MyDish).ToList();
        return View(AllDishes);
    }


//******************************************** ADD CHEFS ********************************

    [HttpPost("chefs/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            // 1-Add
            _context.Add(newChef);
            // 2-Save
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("AddChef");
    }


public IActionResult AddChef()
    {
        return View();
    }


//******************************************* ADD DISHES *******************************
[HttpPost("dish/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            // 1-Add
            _context.Add(newDish);
            // 2-Save
            _context.SaveChanges();
            return RedirectToAction("Privacy");
        }
        return View("AddDish");
    }




public IActionResult AddDish()
    {
        List<Chef> AllChefs = _context.Chefs.ToList();
        ViewBag.AllChefs = AllChefs;
        return View();
    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}