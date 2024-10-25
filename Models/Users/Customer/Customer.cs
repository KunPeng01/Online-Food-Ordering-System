namespace OnlineFoodOrderingSystem.Models.Users.Customer{
    public class Customer:User{
        public string Address{ get; set; }
        public string Phone{ get; set; }

        public List<CustomerPreference>? CustomerPreferences { get; set; }

    }
}