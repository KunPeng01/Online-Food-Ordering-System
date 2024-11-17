using OnlineFoodOrderingSystem.Models.Items;

namespace OnlineFoodOrderingSystem.Data
{
    public static class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var context = serviceProvider.GetRequiredService<OnlineFoodOrderDbContext>();
            context.Database.EnsureCreated();

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Cheeseburger",
                        Description = "Juicy beef patty topped with melted cheese, lettuce, and tomato.",
                        Price = 5.99M,
                        ImageUrl = "https://theeburgerdude.com/wp-content/uploads/2023/03/WBC-Blog-01-1024x1024.jpg"
                    },
                    new Product
                    {
                        Name = "French Fries",
                        Description = "Crispy golden fries seasoned with salt.",
                        Price = 2.49M,
                        ImageUrl = "https://theeburgerdude.com/wp-content/uploads/2023/08/McDons-Fries-1-1024x1024.jpg"
                    },
                    new Product
                    {
                        Name = "Chicken Nuggets",
                        Description = "Cripsy chicken nuggets served with your choice of dipping sauce.",
                        Price = 3.99M,
                        ImageUrl = "https://airfryingfoodie.com/wp-content/uploads/2023/10/air-fryer-chicken-nuggets-copy-3.jpg"
                    },
                    new Product
                    {
                        Name = "Hot Dog",
                        Description = "Grilled sausage served in a bun with mustard and ketchup.",
                        Price = 4.99M,
                        ImageUrl = "https://playswellwithbutter.com/wp-content/uploads/2022/05/Grilled-Hot-Dogs-How-to-Grill-Hot-Dogs-38.jpg"
                    },
                    new Product
                    {
                        Name = "Pizza Margherita",
                        Description = "Classic pizza topped with fresh mozzarella, tomatoes, and basil.",
                        Price = 10.99M,
                        ImageUrl = "https://foodbyjonister.com/wp-content/uploads/2020/01/MargheritaPizza.jpg"
                    },
                    new Product
                    {
                        Name = "Fish and Chips",
                        Description = "Battered fish served with crispy fries and tartar sauce.",
                        Price = 9.99M,
                        ImageUrl = "https://travelandmunchies.com/wp-content/uploads/2022/12/IMG_9513-scaled.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
