using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers;

public class FirstController : Controller 
{
    // Routes 
    /*
        1- path= url
        2- method( GET, POST)
        3- associated function


        python 
        app.route('/users', methods=['GET'])
        def users();
        return smth
    */

    // ! Method Get 
    [HttpGet]
    // ! http: //localhost:5052/ 
    [Route("first")]
    // ! Associated function 
    public string FirstRoute()
    {
        return "Hello From First Controller👾👾👾👾";
    }
    [HttpGet("html")]
    public string Html()
    {
        return "<h1>This is an H1 Tag from First Controller 🐱‍🚀🐱‍🚀🐱‍🚀🐱‍🚀🐱‍🚀<h1>";
    }
    
    // Third route 
    [HttpGet("params/{username}/{age}")]
    public string Params(string username, int age)
    {
        return $"Username : {username}\n Age : {age}";
    }

    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet("dashboard")]
    public ViewResult Dashboard()
    {
        return View();
    }

    [HttpGet("second/{name}/{favNumber}")]
    public ViewResult Second(string name, int favNumber)
    {
        Console.WriteLine($"User Name: {name} \n Favorite Number : {favNumber}");
        ViewBag.Name = name;
        ViewBag.FavNumber = favNumber;
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(string name, int favNumber)
    {
        if(name == "")
        {
            return RedirectToAction("Dashboard");

        }
        Console.WriteLine($"From Data\nName: {name}\nFavorite Number : {favNumber}");
        ViewBag.Name = name;
        ViewBag.FavNumber = favNumber;
        return View("Second");
    }

    // gard route - catch all route
    [HttpGet("{**path}")]
    public ViewResult Error()
    {
        return View();
    }

};

