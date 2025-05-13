using CoreDemo.Areas.Admin.Models;
using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreDemo.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin,Moderator")]
public class AdminRoleController : Controller
{
    private readonly RoleManager<AppRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;

    public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var data = _roleManager.Roles.ToList();
        return View(data);
    }

    public IActionResult AddRole()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddRole(RoleViewModel model)
    {
        if (ModelState.IsValid)
        {
            AppRole role = new AppRole
            {
                Name = model.Name,
            };
            IdentityResult result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult UpdateRole(int id)
    {
        var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
        RoleUpdateViewModel model = new RoleUpdateViewModel
        {
            Id = values.Id,
            Name = values.Name,
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
    {
        if (ModelState.IsValid)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == model.Id);
            values.Name = model.Name;
            var result = await _roleManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
        }

        return View(model);
    }

    public async Task<IActionResult> DeleteRole(int id)
    {
        var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
        var result = await _roleManager.DeleteAsync(values);
        if (result.Succeeded)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }

    public IActionResult UserRoleList()
    {
        var values = _userManager.Users.ToList();
        return View(values);
    }

    public async Task<IActionResult> AssignRole(int id)
    {
        var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
        var roles = _roleManager.Roles.ToList();

        TempData["UserId"] = user.Id;

        var userRoles = await _userManager.GetRolesAsync(user);

        List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
        foreach (var role in roles)
        {
            RoleAssignViewModel m = new();
            m.RoleId = role.Id;
            m.Name = role.Name;
            m.Exist = userRoles.Contains(role.Name);
            model.Add(m);
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
    {
        var userId = (int)TempData["UserId"];
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

        foreach (var item in model)
        {
            if (item.Exist)
            {
                await _userManager.AddToRoleAsync(user, item.Name);
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, item.Name);
            }
        }

        return RedirectToAction("UserRoleList");
    }
}