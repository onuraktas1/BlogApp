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
            var data = _writerManager.GetWriterById(1);
            return View(data);
        }
    }

}
