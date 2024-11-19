using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderingSystem.Data;
using OnlineFoodOrderingSystem.Models.Users.Provider;

namespace OnlineFoodOrderingSystem.Controllers;

public class ProviderController:Controller
{
    private readonly OnlineFoodOrderDbContext _context;
    
    public ProviderController(OnlineFoodOrderDbContext context)
    {
        _context = context;
    }
    
    
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Provider provider)
    {
        if (ModelState.IsValid)
        {
            _context.Providers.Add(provider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(provider);
        
    }
    
    public IActionResult Edit(int id)
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Edit(Provider provider)
    {
        return View();
    }
    
    public IActionResult Delete(int id)
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Delete(Provider provider)
    {
        return View();
    }
    
    public IActionResult Details(int id)
    {
        return View();
    }
    
    public IActionResult ListProvider()
    {
        return View(_context.Providers.ToList());
    }
    
}