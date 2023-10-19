using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

public class WeddingsController : Controller
{


    private readonly WeddingPlannerContext _context;
    public WeddingsController(WeddingPlannerContext context)
    {
        _context = context;
    }




    [HttpGet("/weddings/new")]
    public IActionResult Wedding()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("LogReg", "Users");
        }
        int? userId = (int)HttpContext.Session.GetInt32("userId");
        return View("Wedding");
    }


    [HttpPost("weddings/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {

        if (ModelState.IsValid)
        {

            if (_context.Weddings.Any(u => u.UserId == newWedding.UserId))
            {
                ModelState.AddModelError("Adress", "You Have Already Created a marriage bitch sit down , be humble , sit down");
                return View("Wedding");
            }
            else
            {

                //1 Add 
                _context.Add(newWedding);
                //2 Save 
                _context.SaveChanges();
                return RedirectToAction("Dashboard", "Users");
            }
        }
        return View("Dashboard", "Users");
    }

    [HttpGet("/weddings/{id}")]
    public IActionResult ShowWedding(int id)
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("LogReg");
        }
        Wedding OneWedding = _context.Weddings
                                    .Include(wed => wed.myCreator)
                                    .Include(wed => wed.WeddingParticipation)
                                    .ThenInclude(par => par.User)
                                    .FirstOrDefault(wed => wed.WeddingId == id);
        return View(OneWedding);
    }

    [HttpPost()]
    public IActionResult DeleteWedding(int wedId)
    {
        Wedding? WeddingToDelete = _context.Weddings
        .FirstOrDefault(pat => pat.WeddingId == wedId);
        //1 Add 
        _context.Remove(WeddingToDelete);
        //2 Save
        _context.SaveChanges();
        return RedirectToAction("Dashboard", "Users");
    }



    [HttpGet("/wedding/{wedId}/edit")]
    public IActionResult EditWedding(int wedId)
    {
        Wedding? WeddingToUpdate = _context.Weddings
        .FirstOrDefault(pat => pat.WeddingId == wedId);

        return View(WeddingToUpdate);
    }

    [HttpPost()]
    public IActionResult EditedWedding(Wedding editedWedding)
    {
        Wedding?  WeddingToUpdate = _context.Weddings
        .FirstOrDefault(pat => pat.WeddingId == editedWedding.WeddingId);

        if (ModelState.IsValid)
        {
            WeddingToUpdate.WeddingOne = editedWedding.WeddingOne;
            WeddingToUpdate.WeddingTwo = editedWedding.WeddingTwo;
            WeddingToUpdate.Date = editedWedding.Date;
            WeddingToUpdate.Adress = editedWedding.Adress;
            WeddingToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("ShowWedding",new{id = WeddingToUpdate.WeddingId});
        }
        return View("EditWedding",WeddingToUpdate);
    }













    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
