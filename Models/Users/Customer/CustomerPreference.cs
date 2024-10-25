using OnlineFoodOrderingSystem.Models.Preference;

namespace OnlineFoodOrderingSystem.Models.Users.Customer
{
    public class CustomerPreference
    {
        public int CustomerPreferenceId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int PreferenceId { get; set; }
        public Preference.Preference Preference { get; set; }
    }
}