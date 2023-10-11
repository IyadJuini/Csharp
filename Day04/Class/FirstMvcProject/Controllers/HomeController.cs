using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstMvcProject.Models;

namespace FirstMvcProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public static List<Song> AllSongsList = new();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    // Method GET : / :Create a Song
    public IActionResult Index()
    {
        return View();
    }

    //! Never Ever render on POST Request ==> always redirect
    // // Method POST : /songs/create :Create a Song
    // [HttpPost("/songs/create")]
    // public IActionResult CreateSong(string Title, string Singer, int ReleaseYear, bool IsExplicit)
    // {
    //     System.Console.WriteLine($"Title : {Title}\nReleaseYear : {ReleaseYear}\nSinger : {Singer}\nIsExplicit : {IsExplicit}\n");
    //     ViewBag.Title = Title;
    //     ViewBag.Singer = Singer;
    //     ViewBag.ReleaseYear = ReleaseYear;
    //     ViewBag.IsExplicit = IsExplicit;
    //     return RedirectToAction("AllSongs");
    // }
    // Method POST : /songs/create :Create a Song
    [HttpPost("/songs/create")]
    public IActionResult CreateSong(Song newSong)
    {
        if (ModelState.IsValid)
        {
            System.Console.WriteLine($"Title : {newSong.Title}\nReleaseYear : {newSong.ReleaseYear}\nSinger : {newSong.Singer}\nIsExplicit : {newSong.IsExplicit}\n");
            AllSongsList.Add(newSong);
            return RedirectToAction("AllSongs");
        }
        return View("Index");
    }

    //Method GET : /allSongs : Display all Songs
    public IActionResult AllSongs()
    {
        foreach (var item in AllSongsList)
        {
            System.Console.WriteLine(item.Title);
        }
        return View(AllSongsList);
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
