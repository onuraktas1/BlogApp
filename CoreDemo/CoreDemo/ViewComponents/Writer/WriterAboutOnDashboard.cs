using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        private readonly WriterManager _writerManager = new WriterManager(new EfWriterRepository());

        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;

            var writerId = _writerManager.GetAll().Where(x => x.Mail == userMail).Select(x => x.Id).FirstOrDefault();

            var data = _writerManager.GetWriterById(writerId);
            return View(data);
        }
    }

}
