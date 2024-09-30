using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        private readonly BlogManager _blogManager = new(new EfBlogRepository());
     
        public IActionResult Index()
        {
            Context context = new();
            ViewBag.v1 = context.Blogs.Count();
            ViewBag.v2 = context.Blogs.Where(x => x.WriterId == 1).Count();
            ViewBag.v3 = context.Categories.Count();
            return View();
        }
    }
}
