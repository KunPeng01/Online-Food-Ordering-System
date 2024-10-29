using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderingSystem.Data;
using OnlineFoodOrderingSystem.Models.Items;

namespace OnlineFoodOrderingSystem.Controllers.Administrator
{
    public class AdminController:Controller
    {
        private OnlineFoodOrderDbContext _context;

        public AdminController(OnlineFoodOrderDbContext context){
            _context = context;
        }

        public IActionResult Index(){
            var products = _context.Products.ToList();
            Console.WriteLine("Getting all items");
            return View(products);
        }

        [HttpGet]
        [Route("Admin/CreateProduct")]
        public IActionResult CreateProduct(){
            return View();
        }

        [HttpPost]
        [Route("Admin/CreateProduct")]
        public async Task<IActionResult> CreateProduct(Product product){
            if(ModelState.IsValid){
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                Console.WriteLine("Product Added");
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet]
        [Route("Admin/EditProduct")]
        public IActionResult EditProduct(long id){
            var product = _context.Products.Find(id);
            return View(product);
        }


        [HttpPost]
        [Route("Admin/EditProduct")]
        public async Task<IActionResult> EditProduct(Product product)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // [HttpGet]
        // public async DeleteProduct(long id){
        //     var product = _context.Products.Find(id);

        //     await _context.Products.Remove(product);
        // //     return RedirectToAction(nameof(Index));



         }

    }