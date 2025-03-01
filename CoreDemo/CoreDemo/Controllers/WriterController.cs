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

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        private readonly WriterManager _writerManager = new(new EfWriterRepository());
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

        public IActionResult WriterEditProfile()
        {
            var userMail = User.Identity.Name;

            var writerId = _writerManager.GetAll().Where(x => x.Mail == userMail).Select(x => x.Id).FirstOrDefault();
            var writerData = _writerManager.GetById(writerId);
            return View(writerData);
        }

        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator writerValidator = new();
            writer.Image = "Bos";
            ValidationResult result = writerValidator.Validate(writer);

            if (result.IsValid)
            {
                _writerManager.Update(writer);
                return RedirectToAction("Index", "DashBoard");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
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

    }
}
