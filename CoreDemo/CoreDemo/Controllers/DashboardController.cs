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
        private readonly WriterManager _writerManager = new(new EfWriterRepository());
        private readonly Context _context = new();

        public IActionResult Index()
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _writerManager.GetAll().Where(x => x.Mail == userMail).Select(x => x.Id).FirstOrDefault();
            
            ViewBag.v1 = _context.Blogs.Count();
            ViewBag.v2 = _context.Blogs.Where(x => x.WriterId == writerId).Count();
            ViewBag.v3 = _context.Categories.Count();
            return View();
        }
    }
}