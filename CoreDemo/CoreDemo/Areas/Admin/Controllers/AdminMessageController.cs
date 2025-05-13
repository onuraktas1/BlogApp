using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminMessageController : Controller
{
    private readonly Message2Manager _message2Manager = new(new EfMessage2Repository());
    private readonly Context _context = new();

    public IActionResult InBox()
    {
        var userName = User.Identity.Name;
        var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
        var writerId = _context.Writers.Where(x => x.Mail == userMail).Select(x => x.Id).FirstOrDefault();

        var data = _message2Manager.GetInboxListByWriter(writerId);
        return View(data);
    }

    public IActionResult SendBox()
    {
        var userName = User.Identity.Name;
        var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
        var writerId = _context.Writers.Where(x => x.Mail == userMail).Select(x => x.Id).FirstOrDefault();
        var data = _message2Manager.GetSendBoxListByWriter(writerId);
        return View(data);
    }

    public IActionResult ComposeMessage()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ComposeMessage(Message2 message)
    {
        var userName = User.Identity.Name;
        var userMail = _context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
        var writerId = _context.Writers.Where(x => x.Mail == userMail).Select(x => x.Id).FirstOrDefault();
        message.SenderId = writerId;
        message.ReceiverId = 2; //todo alıcının mail adresine göre id gelecek
        message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        message.Status = true;
        _message2Manager.Add(message);
        return RedirectToAction("SendBox");
    }
}