using System.ComponentModel.DataAnnotations;
using System.Data;

namespace OnlineFoodOrderingSystem.Models.Users{
    public class User{
        [Key]
        public int UserId{ get; set; }
        public string UserName{ get; set; }
        public string Email{ get; set; }
        public string Password{ get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; } 
        public DateTime? CreatedAt{ get; set; } 
    }
}