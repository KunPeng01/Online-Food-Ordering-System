using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using OnlineFoodOrderingSystem.Models.Users.Admin;

namespace OnlineFoodOrderingSystem.CustomTagHelpers;

[HtmlTargetElement("td", Attributes = "i-role")]
public class RoleUsersTH:TagHelper
{
    private UserManager<AppUser> _userManager;
    private RoleManager<IdentityRole> _roleManager;
    
    public RoleUsersTH(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    
    [HtmlAttributeName("i-role")]
    public string Role { get; set; }
    
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        Console.WriteLine("Debugging");
        List<string> names = new List<string>();
        IdentityRole role = await _roleManager.FindByIdAsync(Role);
        if (role != null)
        {
            foreach (var user in _userManager.Users)
            {
                if (user != null && await _userManager.IsInRoleAsync(user, role.Name))
                    names.Add(user.UserName);
                
            }
        }
        output.Content.SetContent(names.Count == 0 ? "No Users" : string.Join(", ", names));
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }


}