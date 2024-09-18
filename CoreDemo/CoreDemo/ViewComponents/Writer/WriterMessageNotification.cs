using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        private readonly MessageManager _messageManager = new(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            string p;
            p = "onuraktas@gmail.com";
            var data = _messageManager.GetInboxListByWriter(p);
            return View(data);
        }
    }
}
