using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new(new EfCategoryRepository());
        public IActionResult Index()
        {
            var data = _categoryManager.GetAll();
            return View(data);
        }
    }
}
