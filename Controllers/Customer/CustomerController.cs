using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.Data;
using OnlineFoodOrderingSystem.Models.Users.Customer;
using SQLitePCL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Controllers.Customer{
    public class CustomerController:Controller{
        private readonly OnlineFoodOrderDbContext _context;
        public CustomerController(OnlineFoodOrderDbContext context){
            _context=context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OnlineFoodOrderingSystem.Models.Users.Customer.Customer customer){
            if(ModelState.IsValid){
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Thanks",customer);
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Index(){
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create(){
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


    }
}