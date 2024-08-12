using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly BlogManager _blogManager = new(new EfBlogRepository());
        private readonly CategoryManager categoryManager = new(new EfCategoryRepository());
        public IActionResult Index()
        {
            return View(_blogManager.GetListWithCategory());
        }

        public IActionResult BlogAllRead(int id)
        {
            var data = _blogManager.GetAll(id);
            return View(data);
        }

        public IActionResult BlogListByWriter()
        {
            var data = _blogManager.GetListWithCategory().Where(x => x.WriterId == 1).ToList();
            return View(data);
        }

        public IActionResult BlogAdd()
        {

            List<SelectListItem> categoryValue = (from x in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.Id.ToString()

                                                  }).ToList();

            ViewBag.CategoryValue = categoryValue;
            return View();
        }


        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            BlogValidator validationRules = new();

            ValidationResult results = validationRules.Validate(blog);

            if (results.IsValid)
            {
                blog.Status = true;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = 1;
                _blogManager.Add(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            Blog blog = _blogManager.GetById(id);

            _blogManager.Delete(blog);

            return RedirectToAction("BlogListByWriter");
        }

        public IActionResult Edit(int id)
        {
            List<SelectListItem> categoryValue = (from x in categoryManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.Id.ToString()

                                                  }).ToList();
            ViewBag.CategoryValue = categoryValue;
            var value = _blogManager.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Edit(Blog blog)
        {
            Blog oldBlog = _blogManager.GetById(blog.Id);
            blog.WriterId = oldBlog.WriterId;
            blog.Status = oldBlog.Status;
            blog.CreateDate = oldBlog.CreateDate;
            _blogManager.Update(blog);
            return RedirectToAction("BlogListByWriter");
        }



    }
}
