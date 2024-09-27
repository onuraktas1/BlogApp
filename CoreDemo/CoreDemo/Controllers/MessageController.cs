using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        private readonly Message2Manager _message2Manager = new(new EfMessage2Repository());
        public IActionResult InBox()
        {
            int id = 2;
            var data = _message2Manager.GetInboxListByWriter(id);
            return View(data);
        }

        public IActionResult MessageDetails(int id)
        {
            var data = _message2Manager.GetById(id);
            return View(data);
        }

    }
}
