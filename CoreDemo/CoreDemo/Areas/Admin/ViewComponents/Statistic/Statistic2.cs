using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        private readonly Context _context = new();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _context.Blogs.OrderByDescending(x => x.Id).Select(x => x.Title).Take(1).FirstOrDefault();
            return View();
        }
    }
}
