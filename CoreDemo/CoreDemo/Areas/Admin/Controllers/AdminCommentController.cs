using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminCommentController : Controller
{
    private readonly CommentManager _commentManager=new(new EfCommentRepository());
    public IActionResult Index()
    {
         var data=_commentManager.GetAllWithBlog();
        return View(data);
    }
}