using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderingSystem.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OnlineFoodOrderingSystem.Models.Users.Admin;

namespace OnlineFoodOrderingSystem.Controllers;

public class HomeController : Controller
{

    private UserManager<AppUser> _userManager;
    
    public HomeController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    } 

    [Authorize(Roles="Customer")]
    public async Task<IActionResult> Secured()
    {
        AppUser user = await _userManager.GetUserAsync(HttpContext.User);
        string message= $"Hello this is customer {user.UserName}";
        
        return View((object)message);

    }
    
    public IActionResult Index()
    {
        return View();
    }
    
}
