using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminBlogController : Controller
{
    private readonly BlogManager _blogManager=new(new EfBlogRepository());
    public IActionResult Index()
    {
        var values=_blogManager.GetListWithCategory();
        return View(values);
    }
}