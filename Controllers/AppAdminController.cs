using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineFoodOrderingSystem.Models.Users.Admin;

namespace OnlineFoodOrderingSystem.Controllers;

public class AppAdminController:Controller
{
    private UserManager<AppUser> _userManager;
    
    public AppAdminController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAdmin(AppAdmin appAdmin)
    {
        if(ModelState.IsValid)
        {
            var user = new AppUser
            {
                UserName = appAdmin.Email,
                Email = appAdmin.Email
            };
            var result = await _userManager.CreateAsync(user, appAdmin.Password);
            if(result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(appAdmin);
    }
    
    [HttpGet]
    public IActionResult CreateAdmin()
    {
        return View();
    }
}