using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        CommentManager _commentManager = new(new EfCommentRepository());
        public IViewComponentResult Invoke()
        {
            var data = _commentManager.GetAll(2);
            return View(data);
        }

    }
}
