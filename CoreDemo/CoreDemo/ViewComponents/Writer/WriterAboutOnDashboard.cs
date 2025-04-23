using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        private readonly WriterManager _writerManager = new WriterManager(new EfWriterRepository());
        private readonly Context _context=new();
        
        // private readonly UserManager<AppUser> _userManager;
        //
        // public WriterAboutOnDashboard(UserManager<AppUser> userManager)
        // {
        //     _userManager = userManager;
        // }
       
        public IViewComponentResult Invoke()
        {
            //  var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //  ViewBag.UserMail = user;

            var userName = User.Identity.Name;
            var userMail = _context.Users.Where(x=>x.UserName==userName).Select(y=>y.Email).FirstOrDefault();
            var writerId = _writerManager.GetAll().Where(x => x.Mail == userMail).Select(x => x.Id).FirstOrDefault();

            var data = _writerManager.GetWriterById(writerId);
            ViewBag.userMail=userName;
            return View(data);
        }
    }
}