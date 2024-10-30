using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderingSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace OnlineFoodOrderingSystem.Controllers;

public class HomeController : Controller
{

    [Authorize]
    public IActionResult Secured()
    {
        return View((object)"Hello");
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
}
