using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.Models.Users.Admin;
using OnlineFoodOrderingSystem.Models.Users.Customer;
using OnlineFoodOrderingSystem.Models.Users.Provider;
using OnlineFoodOrderingSystem.Models.Preference;

namespace OnlineFoodOrderingSystem.Data
{
    public class OnlineFoodOrderDbContext:DbContext
    {
        public OnlineFoodOrderDbContext(DbContextOptions<OnlineFoodOrderDbContext> options):base(options)
        {
        }
        
        public DbSet<Provider> Provider{ get; set; }
        public DbSet<Customer> Customer{ get; set; }
        public DbSet<Admin> Admin{ get; set; }

        public DbSet<CustomerPreference> CustomerPreference{ get; set; }
        public DbSet<Preference> Preference{ get; set; }
    }
}