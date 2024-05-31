using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class ContactController : Controller
	{
		private readonly ContactManager _contactManager = new(new EfContactRepository());
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Contact contact)
		{
			contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
			contact.Status = true;
			_contactManager.Add(contact);
			return RedirectToAction("Index", "Blog");
		}
	}
}
