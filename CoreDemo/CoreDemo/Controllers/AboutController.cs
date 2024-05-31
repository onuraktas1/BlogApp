using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class AboutController : Controller
    {
        private readonly AboutManager _aboutManager = new(new EfAboutRepository());
        public IActionResult Index()
        {
            List<About> data = _aboutManager.GetList();
          
            return View(data);
        }

        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
