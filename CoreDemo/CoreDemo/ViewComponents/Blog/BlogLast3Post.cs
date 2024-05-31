using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
	public class BlogLast3Post : ViewComponent
	{
		private readonly BlogManager _blogManager = new(new EfBlogRepository());

		public IViewComponentResult Invoke()
		{
			var data = _blogManager.GetLast3Blog();
			return View(data);
		}
	}
}
