using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntityFramworkLecture.Models;

namespace EntityFramworkLecture.Controllers;

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

    [HttpPost("songs/create")]
    public IActionResult CreateSong(Song newSong)
    {
        if (ModelState.IsValid)
        {
            // 1 - Add 
            _context.Add(newSong);
            // 2 - Save
            _context.SaveChanges();
            return RedirectToAction("Privacy");
        }
        return View("Index");
    }
    public IActionResult Privacy()
    {
        List<Song> AllSongs = _context.Songs.ToList();
        return View(AllSongs);
    }
    [HttpGet("songs/{songId}/edit")]
    public IActionResult Edit(int songId)
    {
        Song? SongToEdit = _context.Songs.FirstOrDefault(q => q.SongId == songId);
        return View(SongToEdit);
    }

    [HttpPost("")]
    public IActionResult UpdateSong(Song editedSong)
    {
        Song? SongToUpdate = _context.Songs.FirstOrDefault(q => q.SongId == editedSong.SongId);
        if (ModelState.IsValid)
        {
            SongToUpdate.Title = editedSong.Title;
            SongToUpdate.ReleaseYear = editedSong.ReleaseYear;
            SongToUpdate.Singer = editedSong.Singer;
            SongToUpdate.IsExplicit = editedSong.IsExplicit;
            SongToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Privacy");
        }
        return View("Edit", SongToUpdate);
    }
    
    [HttpPost("songs/destroy")]
    public IActionResult DeleteSong(int songId)
    {
        Song? SongToDelete = _context.Songs.FirstOrDefault(s => s.SongId == songId);
        // 1 - Delete
        _context.Songs.Remove(SongToDelete);
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
