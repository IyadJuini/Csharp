using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers;

public class RazorController : Controller
{
        [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }
}