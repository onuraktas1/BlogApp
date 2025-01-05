using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        private readonly BlogManager _blogManager = new(new EfBlogRepository());
        private readonly Context _context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _blogManager.GetAll().Count;
            ViewBag.v2 = _context.Contacts.Count();
            ViewBag.v3 = _context.Comments.Count();
            return View();
        }
    }
}
