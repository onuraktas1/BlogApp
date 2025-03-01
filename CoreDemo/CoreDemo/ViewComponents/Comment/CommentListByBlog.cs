using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        CommentManager _commentManager = new(new EfCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            var data = _commentManager.GetAll(id);
            return View(data);
        }

    }
}
