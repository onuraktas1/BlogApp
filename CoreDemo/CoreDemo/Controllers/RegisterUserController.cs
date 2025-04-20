using BusinessLayer.Abstract;
using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreDemo.Controllers;
[AllowAnonymous]
public class RegisterUserController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterUserController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserSignUpViewModel p)
    {
        if (ModelState.IsValid)
        {
            AppUser appUser = new()
            {
                UserName = p.UserName,
                Email = p.Mail,
                NameSurname = p.NameSurname,
                ImageUrl = "Boş"
            };
            var result = await _userManager.CreateAsync(appUser, p.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
        }

        return View(p);
    }
}