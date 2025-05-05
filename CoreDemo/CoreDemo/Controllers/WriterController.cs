using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System.Security.Claims;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        private readonly WriterManager _writerManager = new(new EfWriterRepository());
        private readonly Context _context = new();
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;
            return View();
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult WriterMail()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        public async Task<IActionResult> WriterEditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.Email = values.Email;
            model.NameSurname = values.NameSurname;
            model.ImageUrl = values.ImageUrl;
            model.UserName = values.UserName;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.Email = model.Email;
            values.NameSurname = model.NameSurname;
            values.ImageUrl = model.ImageUrl;
            values.UserName = model.UserName;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.Password);
            // WriterValidator writerValidator = new();
            // writer.Image = "Bos";
            // ValidationResult result = writerValidator.Validate(writer);
            //
            // if (result.IsValid)
            // {
            var result = await _userManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "DashBoard");
            }
            else
            {
                return View();
            }
            // }
            // else
            // {
            //     foreach (var item in result.Errors)
            //     {
            //         ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //     }
            // }

            // return View();
        }

        [AllowAnonymous, HttpGet]
        public IActionResult WriterAdd()
        {
            return RedirectToAction("Index", "DashBoard");
        }

        [AllowAnonymous, HttpPost]
        public IActionResult WriterAdd(AddProfileImage addProfileImage)
        {
            Writer writer = new Writer();
            if (addProfileImage.Image != null)
            {
                var extension = Path.GetExtension(addProfileImage.Image.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Writer/ImageFiles", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                addProfileImage.Image.CopyTo(stream);
                writer.Image = newImageName;
            }

            writer.Mail = addProfileImage.Mail;
            writer.Name = addProfileImage.Name;
            writer.Password = addProfileImage.Password;
            writer.status = true;
            writer.About = addProfileImage.About;
            _writerManager.Add(writer);

            return RedirectToAction("Index", "DashBoard");
        }

        public async Task<IActionResult> LogOut()
        {
            
            return View("Index");
        }
    }
}