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
                CategoryName = "Teknoloji",
                CategorytCount = 10
            });
            categoryClasses.Add(new CategoryClass
            {
                CategoryName = "Yazılım",
                CategorytCount = 12
            });
            categoryClasses.Add(new CategoryClass
            {
                CategoryName = "Donanım",
                CategorytCount = 5
            });
            categoryClasses.Add(new CategoryClass
            {
                CategoryName = "Spor",
                CategorytCount = 4
            });
            categoryClasses.Add(new CategoryClass
            {
                CategoryName = "Tiyatro",
                CategorytCount = 3
            });

            return Json(new { jsonList = categoryClasses });
        }
    }
}
