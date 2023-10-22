using Craftshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Craftshop.Controllers;

public class CraftsController : Controller

{
    private readonly CraftShopContext _context;
    public CraftsController(CraftShopContext context)
    {
        _context = context;
    }

    // .............................. Check If The User Is Connected ................................
    [HttpGet("crafts/new")]
    public IActionResult SellCraft()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("LogReg","Users");
        }
        return View();
    }
    // .............................................................................................


    // ....................................... CREATE Craft ........................................
    [HttpPost("crafts/create")]
    public IActionResult CreateCraft(Craft newCraft)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newCraft);
            _context.SaveChanges();
            return RedirectToAction("Dashboard","Users");
        }
        return View("SellCraft");
    }
    // ..............................................................................................


    // ...........................GET ALL Crafts With Their Owner....................................
    [HttpGet("crafts")]
    public IActionResult ShopCrafts()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("LogReg","Users");
        }
        List<Craft> AllCrafts = _context.Crafts.Include(craft => craft.Owner).ToList();
        return View(AllCrafts);
    }
    // ................................................................................................


    // ................................ Get ONE Craft By Id With his OWNER (SHOW CRAFT) ............................
    [HttpGet("crafts/{craftId}")]
    public IActionResult ShowCraft(int craftId)
    {
        Craft OneCraft = _context.Crafts.Include(craft => craft.Owner).FirstOrDefault(craft => craft.CraftId == craftId);
        return View(OneCraft);
    }
    // ................................................................................................


    // ........................................ DELETE Craft ..........................................
        [HttpPost()]
    public IActionResult DeleteCraft(int craftId)
    {
        Craft? CraftToDelete = _context.Crafts
        .FirstOrDefault(c => c.CraftId == craftId);
        //1 Add 
        _context.Remove(CraftToDelete);
        //2 Save
        _context.SaveChanges();
        return RedirectToAction("ShopCrafts", "Crafts");
    }
    // .............................................................................................


    // ................................ GET ONE BY ID (Craft To Edit) ...............................
    [HttpGet("/craft/{craftId}/edit")]
    public IActionResult EditCraft(int craftId)
    {
        Craft? CraftToUpdate = _context.Crafts
        .FirstOrDefault(c => c.CraftId == craftId);

        return View(CraftToUpdate);
    }
    // ............................................................................................


    // ..................................... EDIT Craft ............................................
    [HttpPost()]
    public IActionResult EditedCraft(Craft editedCraft)
    {
        Craft? CraftToUpdate = _context.Crafts
        .FirstOrDefault(d => d.CraftId == editedCraft.CraftId);
        if (ModelState.IsValid)
        {
            CraftToUpdate.ImageUrl = editedCraft.ImageUrl;
            CraftToUpdate.Price = editedCraft.Price;
            CraftToUpdate.Title = editedCraft.Title;
            CraftToUpdate.Quantity = editedCraft.Quantity;
            CraftToUpdate.Description = editedCraft.Description;
            CraftToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("ShowCraft",new{craftId = CraftToUpdate.CraftId});
        }
        return View("EditCraft",CraftToUpdate);
    }
    // ...............................................................................................

}

