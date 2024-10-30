using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineFoodOrderingSystem.Models.Users.Admin;

namespace OnlineFoodOrderingSystem.Controllers;

public class AppAdminController:Controller
{
    private UserManager<AppUser> _userManager;
    private IPasswordHasher<AppUser> _passwordHasher;
    
    public AppAdminController(UserManager<AppUser> userManager,IPasswordHasher<AppUser> passwordHasher)
    {
        _userManager = userManager;
        _passwordHasher=passwordHasher;
    }

    public IActionResult Index()
    {
        return View(_userManager.Users);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAdmin(AppAdmin appAdmin)
    {
        if(ModelState.IsValid)
        {
            var user = new AppUser
            {
                UserName = appAdmin.Name,
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

    [HttpGet]
    public async Task<IActionResult> Update(string id)
    {
        AppUser user=await _userManager.FindByIdAsync(id);
        if(user!=null)
        {
            return View(user);
        }else
        {
            return RedirectToAction("Index");
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Update(string id,string email,string password)
    {
        AppUser user=await _userManager.FindByIdAsync(id);
        if(user!=null)
        {
            if (!string.IsNullOrEmpty(email))
                user.Email = email;
            else
                ModelState.AddModelError("", "Email cannot be empty");

            if (!string.IsNullOrEmpty(password))
                user.PasswordHash = _passwordHasher.HashPassword(user, password);
            else
                ModelState.AddModelError("", "Password cannot be empty");

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
        }
        else
            ModelState.AddModelError("", "User Not Found"); 
        
        return RedirectToAction("Index");
    }
    
    private void Errors(IdentityResult result)
    {
        foreach (IdentityError error in result.Errors)
            ModelState.AddModelError("", error.Description);
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        AppUser user=await _userManager.FindByIdAsync(id);
        if(user!=null)
        {
            IdentityResult result=await _userManager.DeleteAsync(user);
            if(result.Succeeded)
                return RedirectToAction("Index");
            else
                Errors(result);
        }
        else
            ModelState.AddModelError("", "User Not Found");
        
        return RedirectToAction("Index",_userManager.Users);
    }
}