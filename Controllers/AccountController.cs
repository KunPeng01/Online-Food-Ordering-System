using Microsoft.AspNetCore.Authorization;
using OnlineFoodOrderingSystem.Models.Users.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using OnlineFoodOrderingSystem.Models.Identity;
using Microsoft.Extensions.Logging;

namespace OnlineFoodOrderingSystem.Controllers;


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
    public IActionResult Login(string returnUrl=null)
    {
        Login login = new Login();
        login.ReturnUrl=returnUrl??Url.Content("~/");
        return View(login);
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(Login login)
    {
        if(ModelState.IsValid)
        {
            AppUser user = await _userManager.FindByEmailAsync(login.Email);
            if(user!=null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                if(result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains("Customer"))
                    {
                        return RedirectToAction("Index", "Customer");
                    }
                }
            }
        }
        ModelState.AddModelError("", "Invalid login attempt");
        return View(login);
    }
    
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
    
    public IActionResult CreateCustomer()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateCustomer(AppAdmin customer)
    {
        if(ModelState.IsValid)
        {
            AppUser user = new AppUser()
            {
                UserName = customer.Name,
                Email = customer.Email
            };
            IdentityResult result = await _userManager.CreateAsync(user, customer.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
                return RedirectToAction("Thanks", "Account");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }
        return View(customer);
    }
    
    public IActionResult Thanks()
    {
        return View();
    }

}