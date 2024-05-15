using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
	public class WriterLastBlog : ViewComponent
	{
		BlogManager _blogManager = new(new EfBlogRepository());

		public IViewComponentResult Invoke()
		{
			var data = _blogManager.GetListByWriter(1);
			return View(data);
		}
	}
}
