using OnlineFoodOrderingSystem.Models.Items;

namespace OnlineFoodOrderingSystem.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductsByIds(IEnumerable<long> ids);
    }
}
