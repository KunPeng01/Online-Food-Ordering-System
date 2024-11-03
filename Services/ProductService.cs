using OnlineFoodOrderingSystem.Data;
using OnlineFoodOrderingSystem.Models.Items;

namespace OnlineFoodOrderingSystem.Services
{
    public class ProductService : IProductService
    {
        private readonly OnlineFoodOrderDbContext _context;

        public ProductService(OnlineFoodOrderDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProductsByIds(IEnumerable<long> ids)
        {
            return _context.Products.Where(p => ids.Contains(p.ProductID)).ToList(); 
        }

    }
}
