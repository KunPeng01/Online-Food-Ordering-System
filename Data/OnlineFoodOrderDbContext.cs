using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.Models.Users.Admin;
using OnlineFoodOrderingSystem.Models.Users.Customer;
using OnlineFoodOrderingSystem.Models.Users.Provider;
using OnlineFoodOrderingSystem.Models.Preference;
using OnlineFoodOrderingSystem.Models.Items;

namespace OnlineFoodOrderingSystem.Data
{
    public class OnlineFoodOrderDbContext : DbContext
    {
        public OnlineFoodOrderDbContext(DbContextOptions<OnlineFoodOrderDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Preference> Preferences { get; set; }
    }
}
