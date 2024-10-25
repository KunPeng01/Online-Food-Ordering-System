namespace OnlineFoodOrderingSystem.Models.Users.Provider{
    public class Provider:User{
        public string CompanyName{ get; set; }
        public string Address{ get; set; }
        public string Phone{ get; set; }
    }
}