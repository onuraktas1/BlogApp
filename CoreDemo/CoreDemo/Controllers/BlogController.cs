using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        BlogManager _blogManager = new(new EfBlogRepository());
        public IActionResult Index()
        {
            return View(_blogManager.GetListWithCategory());
        }

        public IActionResult BlogAllRead(int id)
        {
            var data = _blogManager.GetAll(id);
            return View(data);
        }
    }
}
