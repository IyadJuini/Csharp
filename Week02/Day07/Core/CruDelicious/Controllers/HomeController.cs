using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CruDelicious.Models;

namespace CruDelicious.Controllers;

public class HomeController : Controller
{
    private MyContext _context; //! 5 
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context) //! 6 
    {
        _logger = logger;
        _context = context; //! 7 
    }

    public IActionResult Index()
    {
        return View();
    }
        [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            // 1 - Add 
            _context.Add(newDish);
            // 2 - Save
            _context.SaveChanges();
            return RedirectToAction("Privacy");
        }
        return View("Index");
    }
    public IActionResult Privacy()
    {
        List<Dish> AllDishes = _context.Dishes.ToList();
        return View(AllDishes);
    }
    [HttpGet("dishes/{songId}/edit")]
    public IActionResult Edit(int songId)
    {
        Dish? DishToEdit = _context.Dishes.FirstOrDefault(q => q.DishId == songId);
        return View(DishToEdit);
    }

    [HttpPost("")]
    public IActionResult UpdateDish(Dish editedDish)
    {
        Dish? DishToUpdate = _context.Dishes.FirstOrDefault(q => q.DishId == editedDish.DishId);
        if (ModelState.IsValid)
        {
            DishToUpdate.Name = editedDish.Name;
            DishToUpdate.Chef = editedDish.Chef;
            DishToUpdate.Tastiness = editedDish.Tastiness;
            DishToUpdate.Calories = editedDish.Calories;
            DishToUpdate.Description = editedDish.Description;
            DishToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Privacy");
        }
        return View("Edit", DishToUpdate);
    }
    
    [HttpPost("dishes/destroy")]
    public IActionResult DeleteDish(int songId)
    {
        Dish? DishToDelete = _context.Dishes.FirstOrDefault(s => s.DishId == songId);
        // 1 - Delete
        _context.Dishes.Remove(DishToDelete);
        // 2 - Save
        _context.SaveChanges();
        return RedirectToAction("Privacy");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
