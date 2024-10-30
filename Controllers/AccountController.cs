using Microsoft.AspNetCore.Authorization;
using OnlineFoodOrderingSystem.Models.Users.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using OnlineFoodOrderingSystem.Models.Identity;


namespace OnlineFoodOrderingSystem.Controllers;

[Authorize]
public class AccountController:Controller
{
    private UserManager<AppUser> _userManager;
    private SignInManager<AppUser> _signInManager;
    
    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    [AllowAnonymous]
    public IActionResult Login(string returnUrl)
    {
        Login login = new Login();
        login.ReturnUrl=returnUrl;
        return View(login);
    }
    
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(Login login)
    {
        if (ModelState.IsValid)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(login.Email);
            if (appUser != null)
            {
                await _signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager
                    .PasswordSignInAsync(appUser, login.Password, false, false);
                if (result.Succeeded)
                    return Redirect(login.ReturnUrl ?? "/");
            }
            ModelState.AddModelError(nameof(login.Email), "Login Failed: Invalid Email or password");
        }
        return View(login);
    }
    
    

}