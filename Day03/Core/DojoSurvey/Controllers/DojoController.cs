using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers;

public class DojoController : Controller
{
        [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }


        [HttpGet("result/{name}/{location}/{favLanguage}/{comment}")]
    public ViewResult Result(string name, string location, string  favLanguage, string comment)
    {
        Console.WriteLine($"User Name : {name}\nDojo Location : {location}\nFavorite Language : {favLanguage}\nComment : {comment}");
        ViewBag.Name = name;
        ViewBag.Location = location;
        ViewBag.FavLanguage  = favLanguage;
        ViewBag.Comment  = comment;
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(string name, string location, string  favLanguage, string comment)
    {
        if(name =="")
        {
            return RedirectToAction("");
        }
        Console.WriteLine($"From DataUser Name : {name}\n Dojo Location : {location}\n Favorite Language : {favLanguage}\nComment : {comment}");
        ViewBag.Name = name;
        ViewBag.Location = location;
        ViewBag.FavLanguage  = favLanguage;
        ViewBag.Comment  = comment;
        return View("Result");
    }
}