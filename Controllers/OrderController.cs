using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderingSystem.Data;
using OnlineFoodOrderingSystem.Models;
using OnlineFoodOrderingSystem.Models.Cart;
using System.Collections.Generic;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class OrderController : Controller
    {
        private readonly OnlineFoodOrderDbContext _context;

        public OrderController(OnlineFoodOrderDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Cart/AddToCart")]
        public IActionResult AddToCart(long productId, int quantity)
        {
            // Retrieve the product from the database using the productId
            var product = _context.Products
                .Where(p => p.ProductID == productId) // Use condition here
                .FirstOrDefault(); // This will return the first match or null if not found

            if (product == null)
            {
                return NotFound(); // Return a 404 if the product doesn't exist
            }

            // Get the cart from the session or create a new one if it doesn't exist
            var cart = HttpContext.Session.GetObjectFromJson<List<OrderItem>>("Cart") ?? new List<OrderItem>();

            // Check if the product is already in the cart
            var existingItem = cart.FirstOrDefault(item => item.Product.ProductID == productId);

            if (existingItem != null)
            {
                // If the product is already in the cart, update the quantity by adding the new quantity
                existingItem.Quantity += quantity;
            }
            else
            {
                // Otherwise, add the product to the cart
                cart.Add(new OrderItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }

            // Save the updated cart back to the session
            HttpContext.Session.SetObjectAsJson("Cart", cart);

            // Return a JSON response with the updated cart information or any relevant message
            return Json(new { success = true, message = "Item added to cart", cartCount = cart.Sum(item => item.Quantity) });
        }

        public IActionResult Index()
        {
            // Retrieve the cart from the session
            var cart = HttpContext.Session.GetObjectFromJson<List<OrderItem>>("Cart") ?? new List<OrderItem>();

            // Pass the cart to the view
            return View(cart);
        }
    
        // GET: Checkout
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        // POST: Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(CheckoutModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new
                {
                    Name = model.Name,
                    Address = model.Address,
                    Phone = model.Phone,
                    Email = model.Email,
                    DeliveryMethod = model.DeliveryMethod,
                    CardNumber = model.CardNumber,
                    ExpirationDate = model.ExpirationDate,
                    Cvv = model.Cvv
                };

                // Redirect to an order confirmation page (you could also return a confirmation view here)
                return RedirectToAction("OrderConfirmation", new { orderDetails = order });
            }

            // If validation fails, return the form with validation errors
            return View(model);
        }

        // Order Confirmation Page (for after the order is placed)
        public IActionResult OrderConfirmation(object orderDetails)
        {
            return View(orderDetails);
        }

        public IActionResult ShowCart()
        {
            // Retrieve the cart from the session (or initialize an empty cart if not present)
            var cart = HttpContext.Session.GetObjectFromJson<List<OrderItem>>("Cart") ?? new List<OrderItem>();

            // Pass the cart to the view to display the items
            return View(cart);
        }
    
    }
}
