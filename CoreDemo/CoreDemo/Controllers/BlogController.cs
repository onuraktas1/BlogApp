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
    }
}
