using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BeltExam.Models;

namespace BeltExam.Controllers;

public class LikesController : Controller
{


    private readonly MyContext _context;
    public LikesController(MyContext context)
    {
        _context = context;
    }




    // ..........................................  Create Likes ...................................................

    [HttpPost("likes/create")]
    public IActionResult Like(Like newLike)
    {
        if (ModelState.IsValid)
        {
            // 1-Add
            _context.Add(newLike);
            // 2-Save
            _context.SaveChanges();
            return RedirectToAction("AllPosts", "Posts");
        }
        return RedirectToAction("AllPosts", "Posts");
    }


    // ..........................................  Create Likes ................................................... 
    [HttpPost("likes/destroy")]
    public IActionResult UnLike(Like likeToDelete)
    {

        if (ModelState.IsValid)
        {
            // 1-Add
            _context.Remove(likeToDelete);
            // 2-Save
            _context.SaveChanges();
            return RedirectToAction("AllPosts", "Posts");
        }
        return RedirectToAction("AllPosts", "Posts");

    }


    //..............................................................................................


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}