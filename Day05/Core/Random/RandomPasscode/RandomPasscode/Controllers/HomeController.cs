using System.Diagnostics;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;


namespace RandomPasscode.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
        public static int NumberOfUsers = 0;


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        char[] TheMdp = new char[14] ;

        char[] AlfaNum = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K','L', 'M','N', 'O', 'P' ,'Q' ,'R' ,'S' ,'T' ,'U' ,'V' ,'W' ,'X' ,'Y' ,'Z' ,'0' ,'1' ,'2' ,'3' ,'4' ,'5' ,'6' ,'7' ,'8' ,'9'};
        // System.Console.WriteLine(AlfaNum.Length);
        Random Rnd = new Random();
        for (int i=0; i < 14; i++)
        {
        
        int Mcgregor = Rnd.Next(AlfaNum.Length);
        // System.Console.WriteLine(AlfaNum[Mcgregor]);
        // TheMdp[i]=AlfaNum[Mcgregor];
        TheMdp[i]=(AlfaNum[Mcgregor]);
        }
            System.Console.Write("👹👹",TheMdp);
            var finalMDP= new string(TheMdp);
            HttpContext.Session.SetString("Password",finalMDP);
            NumberOfUsers += 1;
            HttpContext.Session.SetInt32("numberOfUsers", NumberOfUsers);
            // System.Console.WriteLine("THE MDP: "+TheMdp[0]);
        return View("Index", AlfaNum);
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
