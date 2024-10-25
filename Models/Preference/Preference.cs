using OnlineFoodOrderingSystem.Models.Users.Customer;

namespace OnlineFoodOrderingSystem.Models.Preference
{
    public class Preference
    {
        public int PreferenceId { get; set; }
        public string Detail { get; set; }
        public List<CustomerPreference>? CustomerPreferences { get; set; }
    }
}