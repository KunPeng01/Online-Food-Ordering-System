using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.Data;
using OnlineFoodOrderingSystem.Models.Cart;
using OnlineFoodOrderingSystem.Services;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class OrderController : Controller
    {

        private OnlineFoodOrderDbContext _context;
        private readonly IProductService _productService;

        public OrderController(OnlineFoodOrderDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult OrderSummary(Dictionary<long, int> quantities)
        {
            // Get the list of products with selected quantities
            var selectedProducts = _productService.GetProductsByIds(quantities.Keys);
            var orderedProducts = selectedProducts
                .Where(p => quantities[p.ProductID] > 0) // Only include items with quantity > 0
                .Select(p => new OrderItem
                {
                    Product = p,
                    Quantity = quantities[p.ProductID]
                })
                .ToList();

            return View("OrderSummary", orderedProducts);
        }

    }
}
