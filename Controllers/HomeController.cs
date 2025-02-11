using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderingSystem.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OnlineFoodOrderingSystem.Models.Users.Admin;

namespace OnlineFoodOrderingSystem.Controllers;

public class HomeController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {


        return View();

    }

    [Authorize(Roles = "Customer")]
    public async Task<IActionResult> Secured()
    {
        AppUser user = await _userManager.GetUserAsync(HttpContext.User);
        string message = $"Hello this is customer {user.UserName}";

        return View((object)message);
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(Login login, string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;

        if (ModelState.IsValid)
        {
            Console.WriteLine("Login attempt");
            AppUser user = await _userManager.FindByEmailAsync(login.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains("Customer"))
                    {
                        return RedirectToAction("Index", "Customer");
                    }
                    else if (roles.Contains("AppAdmin"))
                    {
                        Console.WriteLine("AppAdmin login");
                        return RedirectToAction("Index", "AppAdmin");
                    }
                    // Add more roles as needed
                }
            }
        }

        ModelState.AddModelError("", "Invalid login attempt");
        Console.WriteLine("Invalid login attempt");
        return View(login);
    }
}
