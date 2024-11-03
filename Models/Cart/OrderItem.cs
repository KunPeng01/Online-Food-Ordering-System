using OnlineFoodOrderingSystem.Models.Items;

namespace OnlineFoodOrderingSystem.Models.Cart
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
