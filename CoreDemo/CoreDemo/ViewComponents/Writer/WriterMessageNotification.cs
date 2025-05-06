using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly Message2Manager _message2Manager = new(new EfMessage2Repository());
        private readonly Context _context = new();
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = _context.Writers.Where(x => x.Mail == userMail).Select(x => x.Id).FirstOrDefault();
            var data = _message2Manager.GetInboxListByWriter(writerId);
            return View(data);
        }
    }
}