using Microsoft.AspNetCore.Authorization;
using OnlineFoodOrderingSystem.Models.Users.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using OnlineFoodOrderingSystem.Models.Identity;
using Microsoft.Extensions.Logging;

namespace OnlineFoodOrderingSystem.Controllers;

[Authorize]
public class AccountController:Controller
{
    private UserManager<AppUser> _userManager;
    private SignInManager<AppUser> _signInManager;
    private ILogger<AccountController> _logger;
    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<AccountController> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
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
        //Fix bug later, model state is not valid (returns false)
        Console.WriteLine(ModelState.IsValid.ToString());
        if (ModelState.IsValid)
        {
            
            AppUser appUser = await _userManager.FindByEmailAsync(login.Email);
            if (appUser != null)
            {
                await _signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager
                    .PasswordSignInAsync(appUser, login.Password, false, false);
                
                if (result.Succeeded)
                {
                    _logger.LogInformation("User {Email} logged in successfully.", login.Email);
                    return Redirect(login.ReturnUrl ?? "/");
                }
                else
                {
                    _logger.LogWarning("Login failed for user {Email}.", login.Email);
                }
            }
            else
            {
                _logger.LogWarning("User {Email} not found.", login.Email);
            }
            ModelState.AddModelError(nameof(login.Email), "Login Failed: Invalid Email or password");
        }
        return View(login);
        
    }
    
    

}