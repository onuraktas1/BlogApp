using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Writer writer)
        {
            Context context = new();
            Writer? data = await context.Writers.FirstOrDefaultAsync(x => x.Mail == writer.Mail && x.Password == writer.Password);
            if (data != null)
            {

                List<Claim> claims = new List<Claim> {

                    new(ClaimTypes.Name,writer.Mail)
                };

                ClaimsIdentity userIdentity = new(claims, "a");
                ClaimsPrincipal principal = new(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Writer");
            }
            else
            {

                return View();
            }
        }
    }
}
//Context context = new();
//Writer? data = context.Writers.FirstOrDefault(x => x.Mail == writer.Mail && x.Password == writer.Password);

//if (data != null)
//{
//    HttpContext.Session.SetString("userName", writer.Mail);
//    return RedirectToAction("Index", "Writer");
//}
//else
//{
//    return View();
//}
