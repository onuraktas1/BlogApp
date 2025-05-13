using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminRoleController : Controller
{
    private readonly RoleManager<AppRole> _roleManager;

    public AdminRoleController(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
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
}