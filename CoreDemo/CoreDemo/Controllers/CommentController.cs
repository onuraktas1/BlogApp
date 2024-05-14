using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class CommentController : Controller
	{
		CommentManager _commentManager = new CommentManager(new EfCommentRepository());
		public IActionResult Index()
		{
			return View();
		}

		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}
		public PartialViewResult PartialCommentListByBlog(int id)
		{
			var data = _commentManager.GetAll(id);
			return PartialView(data);
		}
	}
}
