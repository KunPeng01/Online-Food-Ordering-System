using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.Data;
using OnlineFoodOrderingSystem.Models.Users.Customer;
using SQLitePCL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class CustomerController : Controller
    {
        private readonly OnlineFoodOrderDbContext _context;
        public CustomerController(OnlineFoodOrderDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OnlineFoodOrderingSystem.Models.Users.Customer.Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return View("Thanks", customer);
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Thanks(OnlineFoodOrderingSystem.Models.Users.Customer.Customer customer)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }
        
        [HttpGet]
        public async Task<IActionResult> Update(Models.Users.Customer.Customer customer)
        {
            
            return View(customer);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(Models.Users.Customer.Customer customer, int id)
        {
            if (id != customer.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(List));
            }
            return View(customer);
        }
        
        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.UserId == id);
        }


    }
}