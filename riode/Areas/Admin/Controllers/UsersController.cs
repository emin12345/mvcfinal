using riode.Areas.Admin.ViewModel;

using riode.Helpers.Enums;
using riode.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using riode.Contexts;

namespace riode.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Moderator")]
public class UsersController : Controller
{
    private readonly RiodeDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;

    public UsersController(RiodeDbContext context, IWebHostEnvironment webHostEnvironment, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
        _roleManager = roleManager;
        _userManager = userManager;
    }


    public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.ToListAsync();
        var roles = await _roleManager.Roles.ToListAsync();
        var UserRoles = new List<UserViewModel>();

        foreach (var user in users)
        {
            if (user.UserName != User.Identity.Name)
            {
                var rolesForUser = await _userManager.GetRolesAsync(user);
                UserRoles.Add(new UserViewModel
                {
                    User = user,
                    Roles = rolesForUser,
                });

            }
            
        }
        return View(UserRoles);
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Ban(string id)
    {
        var user = await _userManager.FindByNameAsync(id);
 
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ActionName("Ban")]
    public async Task<IActionResult> BanOrUnbanUser(string id)
    {
        var user = await _userManager.FindByNameAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        if (user.IsActive)
        {
            user.IsActive = false;
        }
        else
        {
            user.IsActive = true;
        }
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Users");

    }

    
}
