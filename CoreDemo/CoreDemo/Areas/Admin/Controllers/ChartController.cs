using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>();

            categoryClasses.Add(new CategoryClass
            {
                categoryname = "Teknoloji",
                categorycount = 10
            });
            categoryClasses.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 12
            });
            categoryClasses.Add(new CategoryClass
            {
                categoryname = "Donanım",
                categorycount = 5
            });
            categoryClasses.Add(new CategoryClass
            {
                categoryname = "Spor",
                categorycount = 4
            });
            categoryClasses.Add(new CategoryClass
            {
                categoryname = "Tiyatro",
                categorycount = 3
            });

            return Json(new { jsonlist = categoryClasses });
        }
    }
}
