using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        private readonly NotificationManager _notificationManager = new(new EfNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var data = _notificationManager.GetAll();
            return View(data);
        }

    }
}
