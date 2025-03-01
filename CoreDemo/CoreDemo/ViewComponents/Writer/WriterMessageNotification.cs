using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly Message2Manager _message2Manager = new(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            int id = 1;
            var data = _message2Manager.GetInboxListByWriter(id);
            return View(data);
        }
    }
}
