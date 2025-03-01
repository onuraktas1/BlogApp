using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager _newsManager = new(new EfNewsLetterDal());
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter p)
        {
            p.Status = true;
            _newsManager.Add(p);
            Response.Redirect("/Blog");
            return PartialView();
        }
    }
}
