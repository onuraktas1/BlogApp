using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using CoreDemo.Models;
using Microsoft.AspNetCore.Identity;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        // [HttpPost]
        // public async Task<IActionResult> Index(Writer writer)
        // {
        //     Context context = new();
        //     Writer? data = await context.Writers.FirstOrDefaultAsync(x => x.Mail == writer.Mail && x.Password == writer.Password);
        //     if (data != null)
        //     {
        //
        //         List<Claim> claims = new List<Claim> {
        //
        //             new(ClaimTypes.Name,writer.Mail)
        //         };
        //
        //         ClaimsIdentity userIdentity = new(claims, "a");
        //         ClaimsPrincipal principal = new(userIdentity);
        //         await HttpContext.SignInAsync(principal);
        //         return RedirectToAction("Index", "Dashboard");
        //     }
        //     else
        //     {
        //         return View();
        //     }
        // }
    }
}