using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        private readonly WriterManager _writerManager = new(new EfWriterRepository());
        public IActionResult Index()
        {
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
        [AllowAnonymous]
        public IActionResult WriterEditProfile()
        {
            var writerData = _writerManager.GetById(1);
            return View(writerData);
        }

        [AllowAnonymous, HttpPost]
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

        [AllowAnonymous, HttpPost]
        public IActionResult WriterAdd(Writer writer)
        {
            _writerManager.Add(writer);

            return RedirectToAction("Index", "DashBoard");
        }

    }
}
