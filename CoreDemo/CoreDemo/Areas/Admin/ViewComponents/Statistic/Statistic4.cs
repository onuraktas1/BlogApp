using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        private readonly Context _context = new();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _context.Admins.Where(x => x.Id == 3).Select(x => x.Name).FirstOrDefault();
            ViewBag.v2 = _context.Admins.Where(x => x.Id == 3).Select(x => x.ImageURL).FirstOrDefault();
            ViewBag.v3 = _context.Admins.Where(x => x.Id == 3).Select(x => x.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
