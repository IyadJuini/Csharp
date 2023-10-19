using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers;

public class ParticipatesController : Controller
{

    
    private readonly WeddingPlannerContext _context;
    public ParticipatesController(WeddingPlannerContext context)
    {
        _context = context; 
    }
    


[HttpPost("participation/create")]
public IActionResult Participate(Participation newPart)
{
    if(ModelState.IsValid)
    {
    //1 Add 
        _context.Add(newPart);

    //2 Save
    _context.SaveChanges();
    return RedirectToAction("Dashboard","Users");
    }
return View();
    
}

    
[HttpPost("participation/destroy")]
public IActionResult UnParticipate(int DeletePart)
{
    Participation participationToDelete = _context.Participations
    .FirstOrDefault(pat => pat.ParticipationId == DeletePart);
    //1 Add 
        _context.Remove(participationToDelete);
    //2 Save
    _context.SaveChanges();
    return RedirectToAction("Dashboard", "Users");
    
}





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}