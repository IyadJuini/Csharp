using Microsoft.AspNetCore.Mvc;

namespace PortfolioOne.Controllers;

public class PortfolioController : Controller
{
        [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

        [HttpGet("/project")]
    public ViewResult Project()
    {
        return View("Project");
    }

        [HttpGet("contact")]
    public ViewResult Contact()
    {
        return View();
    }
}