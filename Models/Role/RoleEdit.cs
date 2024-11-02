using Microsoft.AspNetCore.Identity;
using OnlineFoodOrderingSystem.Models.Users.Admin;

namespace OnlineFoodOrderingSystem.Models.Role;

public class RoleEdit
{
    public IdentityRole Role { get; set; }
    public IEnumerable<AppUser> Members { get; set; }
    public IEnumerable<AppUser> NonMembers { get; set; }
    
    
}